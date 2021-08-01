using System.ComponentModel.DataAnnotations;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity;

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
    }
}
