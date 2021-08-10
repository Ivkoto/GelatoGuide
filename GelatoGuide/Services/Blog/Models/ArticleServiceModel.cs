using System;

namespace GelatoGuide.Services.Blog.Models
{
    public class ArticleServiceModel
    {
        public string Id { get; init; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Image { get; set; }

        public string ArticleText { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }

        public string PostedByName { get; set; }

        public string UserId { get; set; }

        public DateTime PostedByDate { get; set; }

    }
}
