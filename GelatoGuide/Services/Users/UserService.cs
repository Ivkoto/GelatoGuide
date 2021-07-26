using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data;
using System.Collections.Generic;

namespace GelatoGuide.Areas.Administration.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<AdminAllUsersViewModel> users;

        public UserService(GelatoGuideDbContext data)
        {
            this.data = data;
            this.users = new List<AdminAllUsersViewModel>();
        }

        public IEnumerable<AdminAllUsersViewModel> GetAllUser()
        {
            foreach (var user in this.data.Users)
            {
                this.users.Add(new AdminAllUsersViewModel()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });
            }

            return this.users;
        }
    }
}
