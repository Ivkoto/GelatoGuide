using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GelatoGuide.Services.Blog.Models;

namespace GelatoGuide.Models.Blog
{
    public class SearchArticlesViewModel
    {
        public const int PlacesPerPage = 2;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public string PostedByName { get; set; }

        public string PostedByYear { get; set; }

        public string PostedByMonth { get; set; }

        public IEnumerable<AllArticlesServiceModel> Articles;

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<string> Years { get; set; }

        public IEnumerable<string> Months { get; set; }

        public int CurrentPage { get; set; } = 1;
    }
}
