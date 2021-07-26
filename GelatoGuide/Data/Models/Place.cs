using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants;

namespace GelatoGuide.Data.Models
{
    public class Place
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(PlaceNameMinLength), MaxLength(PlaceNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(PlaceDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string MainImageUrl { get; set; }

        [MinLength(MinSinceYear)]
        [MaxLength(MaxSinceYear)]
        public int SinceYear { get; set; }

        public string LogoUrl { get; set; }

        public string WebsiteLink { get; set; }

        public string TakeawayUrl { get; set; }

        public string FoodpandaUrl { get; set; }

        public string GlovoUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public IEnumerable<Image> Images { get; init; } = new List<Image>();
    }
}
