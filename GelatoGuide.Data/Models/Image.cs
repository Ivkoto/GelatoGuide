using System;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Data.Models
{
    public class Image
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Url]
        [Required]
        public string Url { get; set; }

        public string PlaceId { get; set; }

        public Place Place { get; init; }

        public string ShopItemId { get; set; }

        public ShopItem ShopItem { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
