using GelatoGuide.Data.Models;

namespace GelatoGuide.Services.Users.Models
{
    public class UpdateUserServiceModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public User User { get; init; }
    }
}
