using System.Collections.Generic;
using System.Threading.Tasks;
using GelatoGuide.Services.Roles.Models;
using Microsoft.AspNetCore.Identity;

namespace GelatoGuide.Services.Roles
{
    public interface IRoleService
    {
        Task<IdentityRole> FindRole(string roleId);

        Task<RoleServiceModel> GetMembersByRole(string roleId);

        IEnumerable<IdentityRole> GetAllRoles();

        Task<IdentityResult> CreateRole(string roleName);

        Task<List<IdentityResult>> UpdateRole(string roleName, string roleId, string[] addIds, string[] removeIds);

        Task<IdentityResult> DeleteRole(IdentityRole role);
    }
}
