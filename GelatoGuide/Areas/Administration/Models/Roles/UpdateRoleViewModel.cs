using System.Collections.Generic;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GelatoGuide.Areas.Administration.Models.Roles
{
    public class UpdateRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
