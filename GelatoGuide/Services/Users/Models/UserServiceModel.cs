using GelatoGuide.Data.Models;

namespace GelatoGuide.Areas.Administration.Models.Admin
{
    public class UserServiceModel
    {
        public string Id { get; init; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; init; }

        public string PhoneNumber { get; set; }
        
        public string Password { get; init; }

        public User User { get; init; }

        public string Role { get; set; }


    }
}
