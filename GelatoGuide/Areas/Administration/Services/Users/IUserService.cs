using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;

namespace GelatoGuide.Areas.Administration.Services.Users
{
    public interface IUserService
    {
        IEnumerable<AllUsersViewModel> GetAllUser();
    }
}
