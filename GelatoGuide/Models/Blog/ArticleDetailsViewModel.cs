using GelatoGuide.Services.Blog.Models;
using System;
using System.Collections.Generic;

namespace GelatoGuide.Models.Blog;

public class ArticleDetailsViewModel
{
    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Image { get; set; }

    public string ArticleText { get; set; }

    public string SourceName { get; set; }

    public string SourceUrl { get; set; }

    public string PostedByName { get; set; }

    public DateTime PostedByDate { get; set; }

    //ToDo why this class need a collection of articles???
    public IEnumerable<ArticleServiceModel> Articles;
}