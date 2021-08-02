﻿using GelatoGuide.Models.Places;
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
                Places = placeService.GetAllPlaces(searchModel),
                Cities = placeService.GetAllCities(),
                Contries = placeService.GeatAllCountries(),
                TotalPlaces = searchModel.TotalPlaces,
                SearchTerm = searchModel.SearchTerm,
                Country = searchModel.Country,
                City = searchModel.City,
                CurrentPage = searchModel.CurrentPage++
            };
            
            return View(search);
        }
    }
}