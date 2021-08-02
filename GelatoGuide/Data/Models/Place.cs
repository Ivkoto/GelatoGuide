﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants.Place;

namespace GelatoGuide.Data.Models
{
    public class Place
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

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

        public string LogoUrl { get; set; }

        public string WebsiteLink { get; set; }

        [Required]
        public string Country { get; set; }
        
        [Required]
        public string City { get; set; }

        public string Location { get; set; }

        public string TakeawayUrl { get; set; }

        public string FoodpandaUrl { get; set; }

        public string GlovoUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public IEnumerable<Image> Images { get; init; } = new List<Image>();

        public DateTime DateCreated { get; set; }

        public string UserId { get; init; }

        public User User { get; init; }
    }
}