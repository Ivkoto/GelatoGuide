using GelatoGuide.Data.Models;
using GelatoGuide.Services.Roles.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoGuide.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
            => this.roleManager.Roles;

        public async Task<IdentityResult> CreateRole(string roleName)
            => await this.roleManager.CreateAsync(new IdentityRole(roleName));


        public async Task<IdentityRole> FindRole(string roleId)
            => await roleManager.FindByIdAsync(roleId);


        public async Task<IdentityResult> DeleteRole(IdentityRole role)
         => await this.roleManager.DeleteAsync(role);


        public async Task<UpdateRoleServiceModel> GetMembersByRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            var roleMembers = new UpdateRoleServiceModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return roleMembers;
        }

        public async Task<List<IdentityResult>> UpdateRole(
            string roleName, string roleId, string[] addIds, string[] removeIds)
        {
            var results = new List<IdentityResult>();

            IdentityResult result;

            foreach (string userId in addIds ?? new string[] { })
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await userManager.AddToRoleAsync(user, roleName);

                    results.Add(result);
                }
            }

            foreach (string userId in removeIds ?? new string[] { })
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    result = await userManager.RemoveFromRoleAsync(user, roleName);

                    results.Add(result);
                }
            }

            return results;
        }
    }
}
