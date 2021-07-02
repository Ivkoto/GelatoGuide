using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class MapController : Controller
    { 
        public IActionResult Map() => View();
    }
}
