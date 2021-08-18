using GelatoGuide.Models.Places;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Places.Models;
using Microsoft.AspNetCore.Mvc;
using static GelatoGuide.Data.DataConstants;

namespace GelatoGuide.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlaceService placeService;

        public PlacesController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public IActionResult All([FromQuery] AllPlacesServiceModel searchModel)
        {
            var search = this.placeService.AllPlaces(
                searchModel.SearchTerm,
                searchModel.Country,
                searchModel.City,
                searchModel.CurrentPage,
                Places.PlacesPerPage);

            return View(search);
        }
        
        public IActionResult Details(string id)
        {
            var place = this.placeService.PlaceById(id);

            if (place == null)
            {
                //TODO make bad request custom page
                return RedirectToAction("Index", "Shop");
            }

            var viewModel = new PlaceDetailsVewModel()
            {
                Name = place.Name,
                Description = place.Description,
                MainImageUrl = place.MainImageUrl,
                SinceYear = place.SinceYear,
                LogoUrl = place.LogoUrl,
                WebsiteLink = place.WebsiteLink,
                Country = place.Country,
                City = place.City,
                Address = place.Address,
                Location = place.Location,
                TakeawayUrl = place.TakeawayUrl,
                FoodpandaUrl = place.FoodpandaUrl,
                GlovoUrl = place.GlovoUrl,
                FacebookUrl = place.FacebookUrl,
                InstagramUrl = place.InstagramUrl,
                TwitterUrl = place.TwitterUrl
            };

            return View(viewModel);
        }
    }
}
