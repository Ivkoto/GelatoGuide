using System.Diagnostics;
using GelatoGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GelatoGuide.Controllers
{
    public class AboutController : Controller
    {
        
        public IActionResult About()
        {
            return View();
        }
        
    }
}
