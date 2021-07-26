using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Models
{
    public class ViewPlaceFormModel
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string MainImageUrl { get; init; }
        public int SinceYear { get; init; }
        public string LogoUrl { get; init; }
        public string WebsiteUrl { get; init; }
        public string TakeawayUrl { get; init; }
        public string FoodpandaUrl { get; init; }
        public string FacebookUrl { get; init; }
        public string InstagramUrl { get; init; }
        public string TwitterUrl { get; init; }
        public string GlovoUrl { get; init; }
        public IEnumerable<Image> Images { get; init; }
    }
}
