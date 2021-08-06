using System.Linq;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Places.Models;
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
            var placesQuery = this.placeService.GetAllPlaces();

            var places = placesQuery.Select(p => new AllPlaceViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                SinceYear = p.SinceYear,
                Country = p.Country,
                City = p.City,
                DateCreated = p.DateCreated,
                WebsiteLink = p.WebsiteLink
            });

            return View(places);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatePlaceFormModel curPlace)
        {
            if (!ModelState.IsValid)
            {
                return View(curPlace);
            }

            var place = new CreatePlaceServiceModel()
            {
                Name = curPlace.Name,
                City = curPlace.City,
                Country = curPlace.Country,
                Description = curPlace.Description,
                FacebookUrl = curPlace.FacebookUrl,
                FoodpandaUrl = curPlace.FoodpandaUrl,
                GlovoUrl = curPlace.GlovoUrl,
                Images = curPlace.Images,
                InstagramUrl = curPlace.InstagramUrl,
                Location = curPlace.Location,
                LogoUrl = curPlace.LogoUrl,
                MainImageUrl = curPlace.MainImageUrl,
                SinceYear = curPlace.SinceYear,
                TakeawayUrl = curPlace.TakeawayUrl,
                TwitterUrl = curPlace.TwitterUrl,
                WebsiteUrl = curPlace.WebsiteUrl
            };

            placeService.CreatePlace(place);

            return RedirectToAction("All", "Places");
        }
    }
}
