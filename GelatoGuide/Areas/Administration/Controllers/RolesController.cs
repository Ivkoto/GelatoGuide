using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        public IActionResult Index() => View(roleManager.Roles);

        public IActionResult Create() => View();
 

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (!ModelState.IsValid)
            {
                return View(name);
            }

            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));

            if (!result.Succeeded)
            {
                Errors(result);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError(nameof(role),"No role found");

                return View("Index", roleManager.Roles);
            }

            IdentityResult result = await roleManager.DeleteAsync(role);

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
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
