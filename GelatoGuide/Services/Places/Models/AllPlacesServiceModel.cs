﻿using System;
using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Services.Places.Models
{
    public class AllPlacesServiceModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public string MainImageUrl { get; init; }
        
        public int SinceYear { get; init; }

        public string LogoUrl { get; init; }

        public string WebsiteLink { get; init; }

        public string Country { get; set; }
        
        public string City { get; set; }

        public string Location { get; set; }

        public string TakeawayUrl { get; init; }

        public string FoodpandaUrl { get; init; }

        public string GlovoUrl { get; init; }

        public string FacebookUrl { get; init; }

        public string InstagramUrl { get; init; }

        public string TwitterUrl { get; init; }

        public IEnumerable<Image> Images { get; init; }

        public int TotalPlaces { get; set; }

        public DateTime DateCreated { get; set; }
    }
}