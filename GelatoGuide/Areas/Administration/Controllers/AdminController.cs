using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;
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

        public IActionResult AllUsers()
        {
            return View(new AllUsersViewModel());
        }
    }
}