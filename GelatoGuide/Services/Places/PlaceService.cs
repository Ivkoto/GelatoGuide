using System;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Models.Places;
using System.Collections.Generic;
using System.Linq;

namespace GelatoGuide.Services.Places
{
    public class PlaceService : IPlaceService
    {
        private readonly GelatoGuideDbContext data;

        public PlaceService(GelatoGuideDbContext data)
            => this.data = data;


        public void CreatePlace(CreatePlaceFormModel place)
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
                WebsiteLink = place.WebsiteUrl,
                Country = place.Country,
                City = place.City,
                Location = place.Location,
                DateCreated = DateTime.Now
            });

            this.data.SaveChanges();
        }

        //only Administration area
        public IEnumerable<ReadPlaceViewModel> ReadAllPlaces()
            =>
            this.data
                .Places
                .Select(place => new ReadPlaceViewModel()
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


        public IEnumerable<AllPlacesViewModel> GetAllPlaces(SearchPlaceViewModel searchModel)
        {
            var placesQuery = this.data.Places.AsQueryable();

            //filter query if any serach text have been imputed
            if (!string.IsNullOrWhiteSpace(searchModel.SearchTerm))
            {
                placesQuery = placesQuery.Where(p =>
                    p.Name.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    p.SinceYear.ToString().Contains(searchModel.SearchTerm.ToLower())||
                    p.City.ToLower().Contains(searchModel.SearchTerm.ToLower())||
                    p.Country.ToLower().Contains(searchModel.SearchTerm.ToLower()));
            }

            //filter query if country have been selected
            if (!string.IsNullOrWhiteSpace(searchModel.Country))
            {
                placesQuery = placesQuery.Where(p => 
                    p.Country == searchModel.Country);
            }

            //filter query if city have been imputed
            if (!string.IsNullOrWhiteSpace(searchModel.City))
            {
                placesQuery = placesQuery.Where(p => 
                    p.City.ToLower() == searchModel.City.ToLower());
            }

            //restrict receiving query with value lower than 1
            if (searchModel.CurrentPage < 1)
            {
                searchModel.CurrentPage = 1;
            }

            //restrict viewing empty pages
            var totalPlaces = placesQuery.Count();
            var maxPagesCount = (int)Math.Ceiling((double)totalPlaces / SearchPlaceViewModel.PlacesPerPage);
            if (searchModel.CurrentPage > maxPagesCount)
            {
                searchModel.CurrentPage = maxPagesCount;
            }

            searchModel.TotalPlaces = placesQuery.Count();

            var places = placesQuery
                .Skip((searchModel.CurrentPage - 1) * SearchPlaceViewModel.PlacesPerPage)
                .Take(SearchPlaceViewModel.PlacesPerPage)
                .OrderByDescending(p => p)
                .Select(p => new AllPlacesViewModel()
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
                    Location = p.Location
                })
                .ToList();

            return places;
        }

        public IEnumerable<string> GetAllCities()
            => this.data.Places
                .Select(p => p.City)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

        public IEnumerable<string> GeatAllCountries()
            => this.data.Places
                .Select(p => p.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
    }
}
