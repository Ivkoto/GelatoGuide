using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Models.Admin
{
    public class AllUsersViewModel
    {
        [Display(Name = "User Name")]
        public string Username { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
