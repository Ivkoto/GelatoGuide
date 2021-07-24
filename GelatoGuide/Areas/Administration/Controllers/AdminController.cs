using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Areas.Administration.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AllUsers()
        {
            var users = (List<AllUsersViewModel>)userService.GetAllUser();

            return View(users);
        }
    }
}