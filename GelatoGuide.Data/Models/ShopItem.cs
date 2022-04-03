using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static GelatoGuide.Data.Constants.DataConstants.ShopItems;

namespace GelatoGuide.Data.Models
{
    public class ShopItem
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(NameMinLength)]
        public string Name { get; set; }
        
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Precision(12, 2)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Url]
        public string MainImageUrl { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
