using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Places.Models;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var place = this.mapper.Map<PlaceServiceModel>(model);
            place.UserId = userId;

            this.placeService.CreatePlace(place);

            return RedirectToAction("All", "Places");
        }

        public IActionResult Update(string id)
        {
            var place = this.placeService.PlaceById(id);

            if (place == null)
            {
                return RedirectToAction("All", "Places");
            }

            var model = this.mapper.Map<CreatePlaceFormModel>(place);

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

            var serviceModel = this.mapper.Map<PlaceServiceModel>(model);

            this.placeService.UpdatePlace(serviceModel);

            return RedirectToAction("All", "Places");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var place = this.placeService.PlaceById(id);

            if (place == null)
            {
                this.ModelState.AddModelError("", "Place not found!");
                var places = this.placeService.AllPlaces();
                return View("All", places);
            }

            this.placeService.DeletePlace(place);

            return RedirectToAction("All", "Places");
        }

        public IActionResult Details(string id)
        {
            var place = this.placeService.PlaceById(id);

            if (place == null)
            {
                ModelState.AddModelError("", "Place not found!");
                var places = this.placeService.AllPlaces();
                return View("All", places);
            }

            var username = this.userService.Username(place.UserId).Result;

            var placeDetails = this.mapper.Map<PlaceServiceModel>(place);
            placeDetails.Username = username;

            return View(placeDetails);
        }
    }
}
