using GelatoGuide.Areas.Administration.Models.Roles;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        public RolesController(RoleManager<IdentityRole> roleMgr, UserManager<User> userManager)
        {
            roleManager = roleMgr;
            this.userManager = userManager;
        }

        public IActionResult Index() => View(roleManager.Roles);

        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (!ModelState.IsValid)
            {
                return View(name);
            }

            var result = await roleManager.CreateAsync(new IdentityRole(name));

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError(nameof(role), "No role found");

                return View("Index", roleManager.Roles);
            }

            var result = await this.roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var model = new UpdateRoleViewModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return await Update(model.RoleId);
            }

            IdentityResult result;

            foreach (string userId in model.AddIds ?? new string[] { })
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await userManager.AddToRoleAsync(user, model.RoleName);

                    if (!result.Succeeded)
                    {
                        Errors(result);
                    }
                }
            }

            foreach (string userId in model.RemoveIds ?? new string[] { })
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await userManager.RemoveFromRoleAsync(user, model.RoleName);

                    if (!result.Succeeded)
                    {
                        Errors(result);
                    }
                }
            }

            return RedirectToAction("Index");

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
