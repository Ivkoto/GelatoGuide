﻿using GelatoGuide.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static GelatoGuide.Data.Constants.DataConstants.Place;

namespace GelatoGuide.Areas.Administration.Models.Places;

public class CreatePlaceFormModel : IValidatableObject
{
    public string Id { get; init; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength,
        ErrorMessage = "The {0} length should be between {2} and {1} characters long.")]
    public string Name { get; init; }

    [Required]
    public string Description { get; init; }

    [Required]
    [Url]
    [Display(Name = "Main image URL")]
    public string MainImageUrl { get; init; }

    [Required]
    public int SinceYear { get; set; }

    [Url]
    public string LogoUrl { get; init; }

    [Url]
    public string WebsiteUrl { get; init; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Address { get; set; }

    public string Location { get; set; }

    [Url]
    public string TakeawayUrl { get; init; }

    [Url]
    public string FoodpandaUrl { get; init; }

    [Url]
    public string FacebookUrl { get; init; }

    [Url]
    public string InstagramUrl { get; init; }

    [Url]
    public string TwitterUrl { get; init; }

    [Url]
    public string GlovoUrl { get; init; }

    [Url]
    public IEnumerable<Image> Images { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

        if (this.Name != null && !this.Name.Any(char.IsLetter))
        {
            yield return
                new ValidationResult
                ($@"{nameof(this.Name)} must contains at least 2 letters.",
                    new[] { "All" }
                );
        }

        if (this.Description.Length < DescriptionMinLength)
        {
            yield return
                new ValidationResult
                ($"{nameof(this.Description)} must be at least 6 letters long.",
                    new[] { "All" }
                );
        }

        if (this.SinceYear < MinSinceYear || this.SinceYear > MaxSinceYear)
        {
            yield return
                new ValidationResult
                (
                    $"{nameof(this.SinceYear)} value must be betwee {MinSinceYear} and {MaxSinceYear}",
                    new[] { "All" }
                );
        }
    }
}