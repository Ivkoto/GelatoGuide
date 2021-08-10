using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Users.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoGuide.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<AllUsersServiceModel> users;
        private readonly UserManager<User> userManager;
        private readonly IPasswordHasher<User> passwordHasher;

        public UserService(
            GelatoGuideDbContext data,
            UserManager<User> userManager,
            IPasswordHasher<User> passwordHasher)
        {
            this.data = data;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.users = new List<AllUsersServiceModel>();
        }

        public IEnumerable<AllUsersServiceModel> GetAllUser()
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
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = firstRole
                });
            }

            return this.users;
        }

        public async Task<User> GetUserById(string id)
            => await this.userManager.FindByIdAsync(id);

        public async Task<IdentityResult> CreateUser(CreateUserServiceModel model)
        {
            var result = await this.userManager.CreateAsync(new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            }, model.Password);

            return result;
        }

        public async Task<IdentityResult> UpdateUser(UpdateUserServiceModel model)
        {
            var curUser = model.User;

            curUser.UserName = model.Username;
            curUser.Email = model.Email;

            if (model.Password != null)
            {
                curUser.PasswordHash = this.passwordHasher.HashPassword(curUser, model.Password);
            }

            curUser.FullName = model.FullName;
            curUser.PhoneNumber = model.PhoneNumber;

            var result = await this.userManager.UpdateAsync(curUser);

            return result;
        }

        public async Task<IdentityResult> DeleteUser(User user)
            => await this.userManager.DeleteAsync(user);
    }
}
