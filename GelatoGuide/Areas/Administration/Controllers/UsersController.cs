using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Areas.Administration.Models.Users;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult All()
        {
            var users = (List<UserServiceModel>)this.userService.AllUsers();

            return View(users);
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(UserFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = new UserServiceModel()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };

            var result = this.userService.CreateUser(serviceModel).Result;

            if (!result.Succeeded)
            {
                Errors(result);
                return View(model);
            }

            return RedirectToAction("All", "Users");
        }

        public IActionResult Update(string id)
        {
            var user = this.userService.UserById(id).Result;

            if (user == null)
            {
                return BadRequest();
            }

            var model = new UserFormModel()
            {
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserFormModel model)
        {
            model.User = this.userService.UserById(model.Id).Result;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.User == null)
            {
                this.ModelState.AddModelError("", "User not found!");
                return View(model);
            }

            var serviceModel = new UserServiceModel()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                User = model.User
            };

            var result = this.userService.UpdateUser(serviceModel).Result;

            if (!result.Succeeded)
            {
                Errors(result);
                return View(model);
            }

            return RedirectToAction("All", "Users");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user = this.userService.UserById(id).Result;

            if (user == null)
            {
                ModelState.AddModelError(nameof(user.UserName), "User not found!");

                return View("All");
            }

            var result = this.userService.DeleteUser(user).Result;

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("All");
        }


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}