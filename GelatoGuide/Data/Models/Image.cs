using System;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Data.Models
{
    public class Image
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Url { get; set; }

        public string PlaceId { get; set; }

        public Place Place { get; init; }
    }
}
