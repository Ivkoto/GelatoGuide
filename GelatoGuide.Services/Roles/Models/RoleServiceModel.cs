using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GelatoGuide.Services.Roles.Models;

public class RoleServiceModel
{
    public IdentityRole Role { get; set; }
    public IEnumerable<User> Members { get; set; }
    public IEnumerable<User> NonMembers { get; set; }
}