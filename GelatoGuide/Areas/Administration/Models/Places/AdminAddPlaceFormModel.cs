using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GelatoGuide.Data.Models;
using static GelatoGuide.Data.DataConstants;

namespace GelatoGuide.Areas.Administration.Models.Places
{
    public class AdminAddPlaceFormModel
    {
        [Required]
        [StringLength(PlaceNameMaxLength, MinimumLength = PlaceNameMinLength, 
            ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
        public string Name { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        [Url]
        [Display(Name = "Main image URL")]
        public string MainImageUrl { get; init; }
        
        
        public int SinceYear { get; set; }

        [Url]
        public string LogoUrl { get; init; }
        
        [Url]
        public string WebsiteUrl { get; init; }

        [Url]
        public string TakeawayUrl { get; init; }

        [Url]
        public string FoodpandaUrl { get; init; }

        [Url]
        public string FacebookUrl { get; init; }

        [Url]
        public string InstagramUrl { get; init; }

        [Url]
        public string TwitterUrl { get; init; }

        [Url]
        public string GlovoUrl { get; init; }

        [Url]
        public IEnumerable<Image> Images { get; set; }
    }
}
