using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoGuide.Services.Users
{
    public interface IUserService
    {
        IEnumerable<UserServiceModel> GetAllUser();

        Task<User> GetUserById(string id);

        Task<IdentityResult> CreateUser(UserServiceModel model);

        string GetInitialAdminId();

        Task<IdentityResult> UpdateUser(UserServiceModel model);

        Task<IdentityResult> DeleteUser(User user);
    }
}
