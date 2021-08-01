using System;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.DataConstants.Articles;

namespace GelatoGuide.Data.Models
{
    public class Article
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();


        [Required]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }


        [MinLength(SubTitleMinLength)]
        public string SubTitle { get; set; }

        public string Image { get; set; }


        [MinLength(TextMinLength)]
        public string ArticleText { get; set; }

        public string SourceName { get; set; }

        public string SourceUrl { get; set; }


        [MinLength(PostedByNameMinLength)]
        public string PostedByName { get; set; }

        public DateTime PostedByDate { get; set; }

        public string UserId { get; init; }

        public User User { get; init; }

    }
}
