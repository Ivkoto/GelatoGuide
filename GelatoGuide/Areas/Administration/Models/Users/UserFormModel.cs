using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GelatoGuide.Data.Models;
using static GelatoGuide.Data.DataConstants.User;

namespace GelatoGuide.Areas.Administration.Models.Users
{
    public class UserFormModel : IValidatableObject
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
        public string PhoneNumber { get; init; } = "000000";

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, 
            ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
        [Display(Name = "Password")]
        public string Password { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PhoneNumber != null)
            {
                if (!this.PhoneNumber.All(char.IsDigit))
                {
                    yield return new ValidationResult
                    (
                        $"The {nameof(this.PhoneNumber)} must contains only digits."
                    );
                }
            }
        }
    }
}
