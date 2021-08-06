using GelatoGuide.Areas.Administration.Models.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GelatoGuide.Services.Users
{
    public interface IUserService
    {
        public IEnumerable<AllUsersServiceModel> ReadAllUser();
    }
}
