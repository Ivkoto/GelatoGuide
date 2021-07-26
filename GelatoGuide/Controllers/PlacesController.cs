using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class PlacesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
