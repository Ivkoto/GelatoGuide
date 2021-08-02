﻿using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Services.Places;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class PlacesController : Controller
    {

        private readonly IPlaceService placeService;
        public PlacesController(IPlaceService placeService) 
            => this.placeService = placeService;

        public IActionResult All()
        {
            var places = this.placeService.ReadAllPlaces();

            return View(places);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(CreatePlaceFormModel place)
        {
            if (!ModelState.IsValid)
            {
                return View(place);
            }

            placeService.CreatePlace(place);

            return RedirectToAction("All", "Places");
        }
    }
}