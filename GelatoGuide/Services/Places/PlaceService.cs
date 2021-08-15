using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using GelatoGuide.Models.Places;

namespace GelatoGuide.Services.Places
{
    public class PlaceService : IPlaceService
    {
        private readonly GelatoGuideDbContext data;

        public PlaceService(GelatoGuideDbContext data)
            => this.data = data;


        public void CreatePlace(PlaceServiceModel place, string userId)
        {
            this.data.Add(new Place()
            {
                Name = place.Name,
                Description = place.Description,
                MainImageUrl = place.MainImageUrl,
                SinceYear = place.SinceYear,
                LogoUrl = place.LogoUrl,
                Images = place.Images,
                TakeawayUrl = place.TakeawayUrl,
                FoodpandaUrl = place.FoodpandaUrl,
                GlovoUrl = place.GlovoUrl,
                FacebookUrl = place.FacebookUrl,
                InstagramUrl = place.InstagramUrl,
                TwitterUrl = place.TwitterUrl,
                WebsiteLink = place.WebsiteLink,
                Country = place.Country,
                City = place.City,
                Location = place.Location,
                DateCreated = DateTime.Now,
                UserId = userId
            });

            this.data.SaveChanges();
        }

        //for Administration area
        public IEnumerable<PlaceServiceModel> AllPlaces()
            =>
            this.data
                .Places
                .Select(place => new PlaceServiceModel()
                {
                    Id = place.Id,
                    Name = place.Name,
                    WebsiteLink = place.WebsiteLink,
                    SinceYear = place.SinceYear,
                    Country = place.Country,
                    City = place.City,
                    DateCreated = place.DateCreated
                })
                .ToList();

        public Place PlaceById(string id)
            => this.data.Places.First(p => p.Id == id);

        public void UpdatePlace(PlaceServiceModel model)
        {
            var place = this.PlaceById(model.Id);

            place.Name = model.Name;
            place.Description = model.Description;
            place.MainImageUrl = model.MainImageUrl;
            place.SinceYear = model.SinceYear;
            place.LogoUrl = model.LogoUrl;
            place.WebsiteLink = model.WebsiteLink;
            place.Country = model.Country;
            place.City = model.City;
            place.Location = model.Location;
            place.TakeawayUrl = model.TakeawayUrl;
            place.FoodpandaUrl = model.FoodpandaUrl;
            place.GlovoUrl = model.GlovoUrl;
            place.FacebookUrl = model.FacebookUrl;
            place.InstagramUrl = model.InstagramUrl;
            place.TwitterUrl = model.TwitterUrl;
            place.Images = model.Images;

            this.data.SaveChanges();
        }

        public void DeletePlace(Place place)
        {
            this.data.Places.Remove(place);
            this.data.SaveChanges();
        }

        public SearchPlaceViewModel AllPlaces(
            string searchTerm, string country, string city,
            int currentPage, int placesPerPage)
        {
            var placesQuery = this.data.Places.AsQueryable();
            
            if (!placesQuery.Any())
            {
                return null;
            }

            //filter query if any search text have been imputed
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                placesQuery = placesQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    p.SinceYear.ToString().Contains(searchTerm.ToLower()) ||
                    p.City.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Country.ToLower().Contains(searchTerm.ToLower()));
            }

            //filter query if country have been selected
            if (!string.IsNullOrWhiteSpace(country))
            {
                placesQuery = placesQuery.Where(p =>
                    p.Country == country);
            }

            //filter query if city have been imputed
            if (!string.IsNullOrWhiteSpace(city))
            {
                placesQuery = placesQuery.Where(p =>
                    p.City.ToLower() == city.ToLower());
            }

            //restrict receiving query with page value lower than 1
            if (currentPage < 1)
            {
                currentPage = 1;
            }

            //restrict viewing empty pages
            var totalPlaces = placesQuery.Count();
            var maxPagesCount = (int)Math.Ceiling((double)totalPlaces / placesPerPage);
            if (currentPage > maxPagesCount)
            {
                currentPage = maxPagesCount;
            }

            if (!placesQuery.Any())
            {
                return new SearchPlaceViewModel()
                {
                    Places = new List<PlaceServiceModel>(),
                    Cities = this.AllCities(),
                    Countries = this.AllCountries(),
                    TotalPlaces = totalPlaces,
                    SearchTerm = searchTerm,
                    Country = country,
                    City = city,
                    CurrentPage = currentPage
                };
            }

            var places = placesQuery
                .OrderByDescending(p => p.DateCreated)
                .Skip((currentPage - 1) * placesPerPage)
                .Take(placesPerPage)
                .Select(p => new PlaceServiceModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    MainImageUrl = p.MainImageUrl,
                    WebsiteLink = p.WebsiteLink,
                    SinceYear = p.SinceYear,
                    LogoUrl = p.LogoUrl,
                    Images = p.Images
                        .Select(img => new Image()
                        {
                            Url = img.Url,
                            PlaceId = img.PlaceId
                        }).ToList(),
                    FacebookUrl = p.FacebookUrl,
                    InstagramUrl = p.InstagramUrl,
                    TwitterUrl = p.TwitterUrl,
                    GlovoUrl = p.GlovoUrl,
                    FoodpandaUrl = p.FoodpandaUrl,
                    TakeawayUrl = p.TakeawayUrl,
                    Country = p.Country,
                    City = p.City,
                    Location = p.Location,
                    DateCreated = p.DateCreated
                })
                .ToList();

            var result = new SearchPlaceViewModel()
            {
                Places = places.OrderByDescending(p => p.DateCreated),
                Cities = this.AllCities(),
                Countries = this.AllCountries(),
                TotalPlaces = totalPlaces,
                SearchTerm = searchTerm,
                Country = country,
                City = city,
                CurrentPage = currentPage++
            };

            return result;
        }

        public int TotalPlacesCount()
            => this.data.Places.Count();

        public IEnumerable<string> AllCities()
            => this.data.Places
                .Select(p => p.City)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

        public IEnumerable<string> AllCountries()
            => this.data.Places
                .Select(p => p.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
    }
}
