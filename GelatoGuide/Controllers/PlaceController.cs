using GelatoGuide.Models.Places;
using GelatoGuide.Services.Places;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService placeService;

        public PlaceController(IPlaceService placeService)
        {
            this.placeService = placeService;
        }

        public IActionResult All([FromQuery]SearchPlaceViewModel searchModel)
        {
            var search = new SearchPlaceViewModel
            {
                Places = this.placeService.GetAllPlaces(
                    searchModel.SearchTerm,
                    searchModel.Country,
                    searchModel.City,
                    searchModel.CurrentPage, 
                    SearchPlaceViewModel.PlacesPerPage),
                Cities = this.placeService.GetAllCities(),
                Countries = this.placeService.GetAllCountries(),
                TotalPlaces = this.placeService.GetTotalPlacesCount(),
                SearchTerm = searchModel.SearchTerm,
                Country = searchModel.Country,
                City = searchModel.City,
                CurrentPage = searchModel.CurrentPage++
            };
            
            return View(search);
        }
    }
}
