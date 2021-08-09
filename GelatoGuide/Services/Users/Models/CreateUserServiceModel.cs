namespace GelatoGuide.Services.Users.Models
{
    public class CreateUserServiceModel
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public string FullName { get; init; }

        public string PhoneNumber { get; init; }

        public string Password { get; init; }
    }
}
