using System;
using AutoMapper;
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
        private readonly IMapper mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            this.placeService = placeService;
            this.mapper = mapper;
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
            var placeDetails = this.placeService.PlaceById(id);

            if (placeDetails == null)
            {
                return StatusCode(400, "Bad Request!");
                //TODO make bad request custom page
            }

            var viewModel = this.mapper.Map<PlaceDetailsVewModel>(placeDetails);


            return View(viewModel);
        }
    }
}
