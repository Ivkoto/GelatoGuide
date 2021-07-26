using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using System.Collections.Generic;

namespace GelatoGuide.Areas.Administration.Services.Places
{
    public class PlaceService : IPlaceService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<ViewPlaceFormModel> places;

        public PlaceService(GelatoGuideDbContext data)
        {
            this.data = data;
            this.places = new List<ViewPlaceFormModel>();
        }

        public void CreatePlace(AddPlaceFormModel place)
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

        public IEnumerable<ViewPlaceFormModel> GetAllPlaces()
        {
            foreach (var place in this.data.Places)
            {
                this.places.Add(new ViewPlaceFormModel()
                {
                    Id = place.Id,
                    Name = place.Name,
                    WebsiteLink = place.WebsiteLink,
                    SinceYear = place.SinceYear
                });
            }


            return this.places;
        }
    }
}
