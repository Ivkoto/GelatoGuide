using System;
using System.Collections.Generic;
using GelatoGuide.Services.Blog.Models;

namespace GelatoGuide.Models.Blog
{
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

        public IEnumerable<ArticleServiceModel> Articles;
    }
}
