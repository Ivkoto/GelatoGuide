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
                WebsiteLink = place.WebsiteUrl
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
                    SinceYear = place.SinceYear
                })
                .ToList();


        public IEnumerable<AllPlacesViewModel> GetAllPlaces()
            =>
            this.data
                .Places
                .OrderBy(p => p.Name)
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
                    TakeawayUrl = p.TakeawayUrl
                })
                .ToList();
    }
}
