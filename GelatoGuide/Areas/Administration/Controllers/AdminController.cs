using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
