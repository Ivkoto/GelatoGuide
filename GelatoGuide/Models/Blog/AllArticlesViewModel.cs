using System;

namespace GelatoGuide.Models.Blog
{
    public class AllArticlesViewModel
    {
        public string Id { get; init; }
        public string Title { get; init; }

        public string SubTitle { get; set; }

        public string PostedByName { get; set; }

        public DateTime PostedByDate { get; set; }

    }
}
