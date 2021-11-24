using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Infrastructure;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Places.Models;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class PlacesController : AdminController
    {
        private readonly IPlaceService placeService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper, IUserService userService)
        {
            this.placeService = placeService;
            this.mapper = mapper;
            this.userService = userService;
        }

        public IActionResult All()
        {
            var places = this.placeService.AllPlaces();

            return View(places);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatePlaceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else if (this.placeService.IsPlaceNameExist(model.Name))
            {
                ModelState.AddModelError("", $"The place with name {model.Name} already exist in out database.");

                return View(model);
            }

            var userId = this.User.Id();

            var place = this.mapper.Map<PlaceServiceModel>(model);
            place.UserId = userId;

            this.placeService.CreatePlace(place);

            return RedirectToAction("All", "Places");
        }

        public IActionResult Update(string id)
        {
            var placeDetails = this.placeService.PlaceById(id);

            if (placeDetails == null)
            {
                return RedirectToAction("All", "Places");
            }

            var model = this.mapper.Map<CreatePlaceFormModel>(placeDetails);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CreatePlaceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else if (this.placeService.IsPlaceNameExist(model.Name))
            {
                ModelState.AddModelError("", $"The place with name {model.Name} already exist in out database.");

                return View(model);
            }

            var placeDetails = this.mapper.Map<PlaceServiceModel>(model);

            this.placeService.UpdatePlace(placeDetails);

            return RedirectToAction("All", "Places");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {

            if (!this.placeService.IsPlaceExist(id))
            {
                this.ModelState.AddModelError("", "Place not found!");
                var places = this.placeService.AllPlaces();
                return View("All", places);
            }

            this.placeService.DeletePlace(id);

            return RedirectToAction("All", "Places");
        }

        public IActionResult Details(string id)
        {
            var placeDetails = this.placeService.PlaceById(id);

            if (placeDetails == null)
            {
                ModelState.AddModelError("", "Place not found!");
                var places = this.placeService.AllPlaces();
                return View("All", places);
            }

            var username = this.userService.Username(placeDetails.UserId).Result;

            placeDetails.Username = username;

            return View(placeDetails);
        }
    }
}
