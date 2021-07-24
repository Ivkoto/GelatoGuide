using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GelatoGuide.TagHelper
{
    [HtmlTargetElement("td", Attributes = "i-role")]
    public class RoleUserTH : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleUserTH(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HtmlAttributeName("i-role")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();

            IdentityRole role = await roleManager.FindByIdAsync(Role);

            if (role != null)
            {
                foreach (var user in userManager.Users)
                {
                    if (user != null && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }
            //output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
            output.Content.SetContent(names.Count == 0 ? "0" : names.Count.ToString());
        }
    }
}
