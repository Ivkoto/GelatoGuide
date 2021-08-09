using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Users.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoGuide.Services.Users
{
    public interface IUserService
    {
        IEnumerable<AllUsersServiceModel> GetAllUser();

        Task<User> GetUserById(string id);

        Task<IdentityResult> CreateUser(CreateUserServiceModel model);

        Task<IdentityResult> UpdateUser(UpdateUserServiceModel model);

        Task<IdentityResult> DeleteUser(User user);
    }
}
