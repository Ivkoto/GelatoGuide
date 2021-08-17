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
    }
}
