using GelatoGuide.Services.Shop;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers;

public class ShopController : Controller
{
    private readonly IShopService shopService;

    public ShopController(IShopService shopService)
    {
        this.shopService = shopService;
    }

    public IActionResult Index()
    {
        var shopItems = this.shopService.GetAllItems();

        return View(shopItems);
    }

    public IActionResult Details(string id)
        => this.View();
}