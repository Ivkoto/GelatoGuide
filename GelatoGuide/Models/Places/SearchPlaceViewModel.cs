using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GelatoGuide.Services.Places.Models;

namespace GelatoGuide.Models.Places
{
    public class SearchPlaceViewModel
    {
        public const int PlacesPerPage = 4;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public string Country { get; set; }
        public string City { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPlaces { get; set; }
        public IEnumerable<GetPlaceServiceModel> Places { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Cities { get; set; }

    }
}
