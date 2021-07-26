using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AllUsers()
        {
            var users = (List<ReadUsersViewModel>)userService.ReadAllUser();

            return View(users);
        }
    }
}