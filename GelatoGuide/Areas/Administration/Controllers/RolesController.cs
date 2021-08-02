using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GelatoGuide.Data.Models;

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

        [HttpPost]
        public async Task<IActionResult> Update(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError(nameof(role), "No role found");

                return View("Index", roleManager.Roles);
            }

            var result = await this.roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                Errors(result);
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
