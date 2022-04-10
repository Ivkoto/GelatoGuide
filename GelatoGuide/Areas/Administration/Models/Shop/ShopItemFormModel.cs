using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GelatoGuide.Data.Constants.DataConstants.ShopItems;

namespace GelatoGuide.Areas.Administration.Models.Shop;

public class ShopItemFormModel : IValidatableObject
{

    [Required]
    [MinLength(NameMinLength)]
    public string Name { get; set; }

    [Required]
    [MinLength(DescriptionMinLength)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    [Url]
    public string MainImageUrl { get; set; }



    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Price < 0)
        {
            yield return
                new ValidationResult(
                    $"{nameof(this.Price)} cannot be a negative number.", new[] { "All" }
                    );
        }
    }
}