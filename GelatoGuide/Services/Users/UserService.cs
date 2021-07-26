using System.Collections.Generic;
using GelatoGuide.Areas.Administration.Models.Admin;
using GelatoGuide.Data;

namespace GelatoGuide.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GelatoGuideDbContext data;
        private readonly List<ReadUsersViewModel> users;

        public UserService(GelatoGuideDbContext data)
        {
            this.data = data;
            this.users = new List<ReadUsersViewModel>();
        }

        public IEnumerable<ReadUsersViewModel> ReadAllUser()
        {
            foreach (var user in this.data.Users)
            {
                this.users.Add(new ReadUsersViewModel()
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
