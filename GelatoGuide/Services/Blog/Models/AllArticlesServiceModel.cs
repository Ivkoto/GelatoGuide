using System;

namespace GelatoGuide.Services.Blog.Models
{
    public class AllArticlesServiceModel
    {
        public string Id { get; init; }
        public string Title { get; init; }

        public string SubTitle { get; set; }

        public string PostedByName { get; set; }

        public DateTime PostedByDate { get; set; }

    }
}
