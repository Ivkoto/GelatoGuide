using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GelatoGuide.Controllers
{
    public class MapController : Controller
    {
        private readonly IConfiguration config;

        public MapController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Map() => View();
        
    }
}
