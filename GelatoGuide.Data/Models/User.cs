using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static GelatoGuide.Data.DataConstants.User;

namespace GelatoGuide.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public IEnumerable<Place> Places { get; init; } = new List<Place>();

        public IEnumerable<Article> Articles { get; set; } = new List<Article>();

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
