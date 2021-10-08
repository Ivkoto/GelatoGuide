using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants.Place;

namespace GelatoGuide.Data.Models
{
    public class Place
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(NameMinLength), MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string MainImageUrl { get; set; }

        [MinLength(MinSinceYear)]
        [MaxLength(MaxSinceYear)]
        public int SinceYear { get; set; }

        [Url]
        public string LogoUrl { get; set; }

        [Url]
        public string WebsiteLink { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }
        public string Location { get; set; }

        [Url]
        public string TakeawayUrl { get; set; }

        [Url]
        public string FoodpandaUrl { get; set; }

        [Url]
        public string GlovoUrl { get; set; }

        [Url]
        public string FacebookUrl { get; set; }

        [Url]
        public string InstagramUrl { get; set; }

        [Url]
        public string TwitterUrl { get; set; }

        public IEnumerable<Image> Images { get; set; } = new List<Image>();


        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public User User { get; init; }
    }
}
