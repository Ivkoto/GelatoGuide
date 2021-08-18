using GelatoGuide.Areas.Administration.Models.Shop;
using GelatoGuide.Services.Shop;
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

            return View();
        }
    }
}
