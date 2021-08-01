using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static GelatoGuide.Data.DataConstants.User;

namespace GelatoGuide.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
    }
}
