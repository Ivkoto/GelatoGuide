﻿using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Users;
using Microsoft.AspNetCore.Identity;

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

        public IActionResult All()
        {
            var users = (List<UserServiceModel>)this.userService.GetAllUser();

            return View(users);
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(CreateUserFormModel model)
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
            var user = this.userService.GetUserById(id).Result;

            if (user == null)
            {
                return BadRequest();
            }

            var model = new UpdateUserFormModel()
            {
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateUserFormModel model)
        {
            model.User = this.userService.GetUserById(model.Id).Result;

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
            var user = this.userService.GetUserById(id).Result;

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