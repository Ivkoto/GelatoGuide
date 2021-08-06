using GelatoGuide.Areas.Administration.Models.Roles;
using GelatoGuide.Services.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public IActionResult All() => View(this.roleService.GetAllRoles());

        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create([Required] string roleName)
        {
            if (!ModelState.IsValid)
            {
                return View(roleName);
            }

            var result = this.roleService.CreateRole(roleName).Result;

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("All");
        }


        [HttpPost]
        public IActionResult Delete(string id)
        {
            var role = this.roleService.FindRole(id).Result;

            if (role == null)
            {
                ModelState.AddModelError(nameof(role), "No role found");

                return View("All", this.roleService.GetAllRoles());
            }

            var result = this.roleService.DeleteRole(role).Result;

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("All");
        }

        public IActionResult Update(string id)
        {
            var roleMembers = this.roleService.GetMembersByRole(id).Result;

            return View(roleMembers);
        }

        [HttpPost]
        public IActionResult Update(UpdateRoleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return Update(model.RoleId);
            }

            var results = this.roleService
                .UpdateRole(model.RoleName, model.RoleId, model.AddIds, model.RemoveIds);


            foreach (var result in results.Result)
            {
                if (!result.Succeeded)
                {
                    Errors(result);
                }
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
