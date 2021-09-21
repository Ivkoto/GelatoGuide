using System;

namespace GelatoGuide.Areas.Administration.Models.Blog
{
    public class ArticleDetailsViewModel
    {
        public string Id { get; init; }
        
        public string Title { get; set; }
        
        public string SubTitle { get; set; }
        
        public string Image { get; set; }
        
        public string ArticleText { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }
        
        public string PostedByName { get; set; }

        public DateTime PostedByDate { get; set; }

        public string UserId { get; init; }

        public string UserName { get; init; }

    }
}
