using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static GelatoGuide.Data.Constants.DataConstants.Articles;

namespace GelatoGuide.Areas.Administration.Models.Blog;

public class CreateArticleFormModel : IValidatableObject
{
    [Required]
    public string Title { get; init; }

    public string SubTitle { get; init; }

    [Url]
    public string Image { get; init; }

    public string ArticleText { get; init; }

    public string SourceName { get; init; }

    [Url]
    public string SourceUrl { get; init; }

    public string PostedByName { get; init; }



    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

        if (this.Title != null && !this.Title.Any(char.IsLetter))
        {
            yield return
                new ValidationResult
                ($@"Title must contains at least {TitleMinLength} letters.",
                    new[] { "Title" }
                );
        }

        if (this.SubTitle != null && !this.SubTitle.Any(char.IsLetter))
        {
            yield return
                new ValidationResult
                (
                    $@"Sub-title must contains at least {SubTitleMinLength} letters.",
                    new[] { "SubTitle" }
                );
        }

        if (this.ArticleText != null && !this.ArticleText.Any(char.IsLetter))
        {
            yield return
                new ValidationResult
                ($@"Article text must contains at least {TextMinLength} letters.",
                    new[] { "ArticleText" }
                );
        }

        if (this.PostedByName != null && !this.PostedByName.Any(char.IsLetter))
        {
            yield return
                new ValidationResult
                ($@"Posted by name must contains at least {PostedByNameMinLength} letters.",
                    new[] { "PostedByName" }
                );
        }

        if (this.SourceName != null && !this.SourceName.Any(char.IsLetter))
        {
            yield return
                new ValidationResult($@"Source name must contains at least {SourceNameMinLength} letters.",
                    new[] { "SourceName" }
                );
        }
    }
}