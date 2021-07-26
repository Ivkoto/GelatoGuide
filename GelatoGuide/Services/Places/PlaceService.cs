using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Models;

namespace GelatoGuide.Services.Places
{
    public class PlaceService : IPlaceService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<AdminViewPlaceFormModel> places;
        private readonly List<ViewPlaceFormModel> mainViewPlaces;

        public PlaceService(GelatoGuideDbContext data)
        {
            this.data = data;
            this.mainViewPlaces = new List<ViewPlaceFormModel>();
            this.places = new List<AdminViewPlaceFormModel>();
        }

        public void CreatePlace(AdminAddPlaceFormModel place)
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

        //for administration area
        public IEnumerable<AdminViewPlaceFormModel> GetAllPlaces()
        {
            foreach (var place in this.data.Places)
            {
                this.places.Add(new AdminViewPlaceFormModel()
                {
                    Id = place.Id,
                    Name = place.Name,
                    WebsiteLink = place.WebsiteLink,
                    SinceYear = place.SinceYear
                });
            }


            return this.places;
        }

        public IEnumerable<ViewPlaceFormModel> GetAllPlacesMainView()
        {
            foreach (var place in this.data.Places)
            {
                this.mainViewPlaces.Add(new ViewPlaceFormModel()
                {
                    Description = place.Description,
                    MainImageUrl = place.MainImageUrl,
                    SinceYear = place.SinceYear,
                    FacebookUrl = place.FacebookUrl,
                    FoodpandaUrl = place.FoodpandaUrl,
                    GlovoUrl = place.GlovoUrl,
                    Images = place.Images,
                    InstagramUrl = place.InstagramUrl,
                    LogoUrl = place.LogoUrl,
                    Name = place.Name,
                    TakeawayUrl = place.TakeawayUrl,
                    TwitterUrl = place.TwitterUrl,
                    WebsiteUrl = place.WebsiteLink
                });
            }

            return this.mainViewPlaces;
        }
    }
}
