using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Services.Blog.Models;

public class AllArticlesServiceModel
{
    public int CurrentPage { get; set; } = 1;

    public int TotalArticles { get; set; }

    //from post request from the search box
    [Display(Name = "Search")]
    public string SearchTerm { get; init; }

    public string PostedByName { get; set; }

    public string PostedByYear { get; set; }

    public string PostedByMonth { get; set; }

    //all the articles that will be visible in the page
    public IEnumerable<ArticleServiceModel> Articles;

    //for drop down menus in the search box
    public IEnumerable<string> PostedByNames { get; set; }

    public IEnumerable<string> Years { get; set; }

    public IEnumerable<string> Months { get; set; }
}