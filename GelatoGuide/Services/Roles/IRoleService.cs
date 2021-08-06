using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GelatoGuide.Services.Roles
{
    interface IRoleService
    {
        IEnumerable<IdentityRole> GetAllRoles();

        void CreateRole();

        void DeleteRole();

        void UpdateRole();
    }
}
