using GelatoGuide.Areas.Administration.Models.Roles;
using GelatoGuide.Services.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Controllers;

public class RolesController : AdminController
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
            return View(roleName);
        }

        return RedirectToAction("All");
    }


    public IActionResult Update(string id)
    {
        var roleMembers = this.roleService.GetMembersByRole(id).Result;

        return View(roleMembers);
    }

    [HttpPost]
    public IActionResult Update(CreateRoleFormModel model)
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
                return View(model.RoleId);
            }
        }

        return RedirectToAction("All");

    }

    [HttpPost]
    public IActionResult Delete(string id)
    {
        var role = this.roleService.FindRole(id).Result;

        if (role == null)
        {
            ModelState.AddModelError(nameof(role), "Role not found!");

            return View("All");
        }

        var result = this.roleService.DeleteRole(role).Result;

        if (!result.Succeeded)
        {
            Errors(result);
        }

        return RedirectToAction("All", "Roles");
    }

    private void Errors(IdentityResult result)
    {
        foreach (IdentityError error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}