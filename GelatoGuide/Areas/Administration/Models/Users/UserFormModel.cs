using System.ComponentModel.DataAnnotations;
using GelatoGuide.Data.Models;
using static GelatoGuide.Data.DataConstants.User;

namespace GelatoGuide.Areas.Administration.Models.Users
{
    public class UserFormModel
    {
        public string Id { get; init; }

        public User User { get; set; }

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, 
            ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
        [Display(Name = "Username")]
        public string Username { get; init; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; init; }

        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength, 
            ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
        [Display(Name = "Username")]
        public string FullName { get; init; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; init; }

        
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, 
            ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
        [Display(Name = "Password")]
        public string Password { get; init; }
        
    }
}
