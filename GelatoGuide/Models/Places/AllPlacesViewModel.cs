using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Models.Places
{
    public class AllPlacesViewModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string MainImageUrl { get; set; }
        
        public int SinceYear { get; set; }

        public string LogoUrl { get; set; }

        public string WebsiteLink { get; set; }

        public string TakeawayUrl { get; set; }

        public string FoodpandaUrl { get; set; }

        public string GlovoUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string TwitterUrl { get; set; }

        public IEnumerable<Image> Images { get; init; }
    }
}
