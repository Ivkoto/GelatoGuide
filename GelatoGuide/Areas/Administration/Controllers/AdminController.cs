using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    { 
        public IActionResult Index()
        {
            return this.View();
        }

    }
}
