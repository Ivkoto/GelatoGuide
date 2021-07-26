using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;

namespace GelatoGuide.Services.Users
{
    public interface IUserService
    {
        IEnumerable<ReadUsersViewModel> ReadAllUser();
    }
}
