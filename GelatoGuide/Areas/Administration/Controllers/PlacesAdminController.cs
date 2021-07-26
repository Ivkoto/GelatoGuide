using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Services.Places;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class PlacesAdminController : Controller
    {

        private readonly IPlaceService placeService;
        public PlacesAdminController(IPlaceService placeService) 
            => this.placeService = placeService;

        public IActionResult All()
        {
            var places = this.placeService.GetAllPlaces();

            return View(places);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AdminAddPlaceFormModel place)
        {
            if (!ModelState.IsValid)
            {
                return View(place);
            }

            placeService.CreatePlace(place);

            return RedirectToAction("All", "PlacesAdmin");
        }
    }
}
