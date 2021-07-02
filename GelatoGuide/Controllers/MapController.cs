using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GelatoGuide.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MapController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Map() => View();
    }
}
