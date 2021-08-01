using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult AllUsers()
        {
            var users = (List<ReadUsersViewModel>)userService.ReadAllUser();

            return View(users);
        }
    }
}