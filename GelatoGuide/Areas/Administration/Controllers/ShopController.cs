using GelatoGuide.Areas.Administration.Models.Shop;
using GelatoGuide.Services.Shop;
using GelatoGuide.Services.Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class ShopController : AdminController
    {
        private readonly IShopService shopService;

        public ShopController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public IActionResult All()
        {
            var allItems = this.shopService.GetAllItems();

            return View(allItems);
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(ShopItemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var item = new ShopItemServiceModel()
            {
                Name = model.Name,
                Description = model.Description,
                MainImageUrl = model.MainImageUrl,
                Price = model.Price
            };

            this.shopService.CreateItem(item);

            return RedirectToAction("All", "Shop");
        }

        public IActionResult Update(string id)
        {
            var item = this.shopService.GetItemById(id);

            var model = new ShopItemFormModel()
            {
                Name = item.Name,
                Description = item.Description,
                MainImageUrl = item.MainImageUrl,
                Price = item.Price
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ShopItemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                View(model);
            }

            var serviceModel = new ShopItemServiceModel()
            {
                //ToDo should add Id value
                Name = model.Name,
                Description = model.Description,
                MainImageUrl = model.MainImageUrl,
                Price = model.Price
            };

            this.shopService.UpdateItem(serviceModel);
            
            return RedirectToAction("All", "Shop");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            this.shopService.Delete(id);

            return RedirectToAction("All", "Shop");
        }
    }
}
