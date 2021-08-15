using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
            => View();
    }
}
