using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class HomeController : AdminController
    { 
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
