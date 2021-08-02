using GelatoGuide.Areas.Administration.Models.Admin;
using System.Collections.Generic;

namespace GelatoGuide.Services.Users
{
    public interface IUserService
    {
        IEnumerable<ReadUsersViewModel> ReadAllUser();
    }
}
