using System.Collections.Generic;

namespace GelatoGuide.Models.Places
{
    public class SearchPlaceViewModel
    {
        public IEnumerable<string> SearchTerm { get; init; }
        public IEnumerable<AllPlacesViewModel> Places { get; set; }
    }
}
