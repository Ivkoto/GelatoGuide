using System;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants.ShopItems;

namespace GelatoGuide.Data.Models
{
    public class ShopItem
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string MainImageUrl { get; set; }
    }
}
