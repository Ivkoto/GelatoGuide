using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Models.Places
{
    public class AllPlacesViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        
        public string Description { get; init; }
        
        public string MainImageUrl { get; init; }
        
        public int SinceYear { get; init; }

        public string LogoUrl { get; init; }

        public string WebsiteLink { get; init; }

        public string TakeawayUrl { get; init; }

        public string FoodpandaUrl { get; init; }

        public string GlovoUrl { get; init; }

        public string FacebookUrl { get; init; }

        public string InstagramUrl { get; init; }

        public string TwitterUrl { get; init; }

        public IEnumerable<Image> Images { get; init; }
    }
}
