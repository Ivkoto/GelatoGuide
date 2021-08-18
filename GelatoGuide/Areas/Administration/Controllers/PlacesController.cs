using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Places.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class PlacesController : AdminController
    {
        private readonly IPlaceService placeService;

        public PlacesController(IPlaceService placeService)
            => this.placeService = placeService;

        public IActionResult All()
        {
            var placesQuery = this.placeService.AllPlaces();

            var places = placesQuery.Select(p => new PlacesViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                SinceYear = p.SinceYear,
                Country = p.Country,
                City = p.City,
                Address = p.Address,
                DateCreated = p.DateCreated,
                WebsiteLink = p.WebsiteLink
            });

            return View(places);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(PlaceFormModel curPlace)
        {
            if (!ModelState.IsValid)
            {
                return View(curPlace);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var place = new PlaceServiceModel()
            {
                Name = curPlace.Name,
                City = curPlace.City,
                Country = curPlace.Country,
                Address = curPlace.Address,
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
                WebsiteLink = curPlace.WebsiteUrl,
                UserId = userId
            };

            this.placeService.CreatePlace(place, userId);

            return RedirectToAction("All", "Places");
        }

        public IActionResult Update(string id)
        {
            var place = this.placeService.PlaceById(id);

            if (place == null)
            {
                return RedirectToAction("All", "Places");
            }

            var model = new PlaceFormModel()
            {
                Name = place.Name,
                Description = place.Description,
                MainImageUrl = place.MainImageUrl,
                City = place.City,
                Country = place.Country,
                Address = place.Address,
                SinceYear = place.SinceYear,
                LogoUrl = place.LogoUrl,
                Location = place.Location,
                WebsiteUrl = place.WebsiteLink,
                Images = place.Images,
                InstagramUrl = place.InstagramUrl,
                FacebookUrl = place.FacebookUrl,
                TwitterUrl = place.TwitterUrl,
                FoodpandaUrl = place.FoodpandaUrl,
                GlovoUrl = place.GlovoUrl,
                TakeawayUrl = place.TakeawayUrl
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PlaceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = new PlaceServiceModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                MainImageUrl = model.MainImageUrl,
                SinceYear = model.SinceYear,
                LogoUrl = model.LogoUrl,
                WebsiteLink = model.WebsiteUrl,
                Country = model.Country,
                City = model.City,
                Address = model.Address,
                Location = model.Location,
                TakeawayUrl = model.TakeawayUrl,
                FoodpandaUrl = model.FoodpandaUrl,
                FacebookUrl = model.FacebookUrl,
                InstagramUrl = model.InstagramUrl,
                TwitterUrl = model.TwitterUrl,
                GlovoUrl = model.GlovoUrl,
                Images = model.Images
            };

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
                return View("All");
            }

            this.placeService.DeletePlace(place);

            return RedirectToAction("All", "Places");
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
