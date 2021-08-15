using GelatoGuide.Models.Places;
using GelatoGuide.Services.Places;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlaceService placeService;

        public PlacesController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public IActionResult All([FromQuery] SearchPlaceViewModel searchModel)
        {
            var search = this.placeService.AllPlaces(
                searchModel.SearchTerm,
                searchModel.Country,
                searchModel.City,
                searchModel.CurrentPage,
                SearchPlaceViewModel.PlacesPerPage);

            return View(search);
        }
    }
}
