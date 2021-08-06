using System.Collections.Generic;
using System.Threading.Tasks;
using GelatoGuide.Services.Roles.Models;
using Microsoft.AspNetCore.Identity;

namespace GelatoGuide.Services.Roles
{
    public interface IRoleService
    {
        public IEnumerable<IdentityRole> GetAllRoles();

        public Task<IdentityResult> CreateRole(string roleName);

        public Task<IdentityRole> FindRole(string roleId);
        public Task<IdentityResult> DeleteRole(IdentityRole role);

        public Task<UpdateRoleServiceModel> GetMembersByRole(string roleId);

        public Task<List<IdentityResult>> UpdateRole(string roleName, string roleId, string[] addIds, string[] removeIds);
    }
}
