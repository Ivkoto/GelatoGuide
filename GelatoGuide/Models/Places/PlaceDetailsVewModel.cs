using System;
using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Models.Places
{
    public class PlaceDetailsVewModel
    {
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public string MainImageUrl { get; init; }
        
        public int SinceYear { get; init; }

        public string LogoUrl { get; init; }

        public string WebsiteLink { get; init; }

        public string Country { get; set; }
        
        public string City { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public string TakeawayUrl { get; set; }

        public string FoodpandaUrl { get; set; }

        public string GlovoUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
