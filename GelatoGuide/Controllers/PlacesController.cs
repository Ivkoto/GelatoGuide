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

        public IActionResult All([FromQuery]SearchPlaceViewModel searchModel)
        {
            var search = new SearchPlaceViewModel
            {
                Places = placeService.GetAllPlaces(searchModel),
                Cities = placeService.GetAllCities(),
                Contries = placeService.GeatAllCountries(),
                SearchTerm = searchModel.SearchTerm,
                Country = searchModel.Country,
                City = searchModel.City
            };
            
            return View(search);
        }
    }
}
