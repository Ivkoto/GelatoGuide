using GelatoGuide.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Models.Admin
{
    public class ReadUsersViewModel : User
    {
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "User role")]
        public string Role { get; set; }
    }
}
