using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Data.Models
{
    public class Order
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public long OrderNumber { get; set; }

        public string BuyerId { get; set; }

        public Buyer Buyer { get; set; }

        public IEnumerable<ShopItem> Items { get; set; }

        public ShippingAddress ShippingAddress { get; set; }
        
        public string UserId { get; set; }

        public User User { get; set; }

        public string Description { get; set; }

    }
}
