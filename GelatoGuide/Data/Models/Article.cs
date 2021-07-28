using System;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants;

namespace GelatoGuide.Data.Models
{
    public class Article
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();


        [Required]
        [MinLength(ArticleTitleMinLength)]
        public string Title { get; set; }


        [MinLength(ArticleSubTitleMinLength)]
        public string SubTitle { get; set; }

        public string Image { get; set; }


        [MinLength(ArticleTextMinLength)]
        public string ArticleText { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }


        [MinLength(ArticlePostedByNameMinLenght)]
        public string PostedByName { get; set; }

        public DateTime PostedByDate { get; set; }

    }
}
