using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace GelatoGuide.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<AllUsersServiceModel> users;
        private readonly UserManager<User> userManager;

        public UserService(GelatoGuideDbContext data, UserManager<User> userManager)
        {
            this.data = data;
            this.userManager = userManager;
            this.users = new List<AllUsersServiceModel>();
        }

        public IEnumerable<AllUsersServiceModel> ReadAllUser()
        {
            foreach (var user in this.data.Users)
            {
                var userRoles = userManager.GetRolesAsync(user).Result;
                var firstRole = string.Empty;

                if (userRoles.Count > 0)
                {
                    firstRole = userRoles.First();
                }

                this.users.Add(new AllUsersServiceModel()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = firstRole
                });
            }

            return this.users;
        }
    }
}
