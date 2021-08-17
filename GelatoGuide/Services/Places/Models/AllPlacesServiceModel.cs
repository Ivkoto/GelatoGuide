using System.Collections.Generic;

namespace GelatoGuide.Services.Places.Models
{
    public class AllPlacesServiceModel
    {
        public const int PlacesPerPage = 4;

        public string SearchTerm { get; init; }

        public string Country { get; set; }
        public string City { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPlaces { get; set; }
        public IEnumerable<PlaceServiceModel> Places { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Cities { get; set; }

    }
}
