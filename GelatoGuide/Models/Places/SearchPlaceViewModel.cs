using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Models.Places
{
    public class SearchPlaceViewModel
    {
        public const int PlacesPerPage = 2;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public string Country { get; set; }
        public string City { get; set; }
        public IEnumerable<AllPlacesViewModel> Places { get; set; }

        public IEnumerable<string> Contries { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public int CurrentPage { get; set; } = 1;
    }
}
