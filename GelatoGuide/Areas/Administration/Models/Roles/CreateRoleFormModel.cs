using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Models.Roles;

public class CreateRoleFormModel
{
    [Required]
    public string RoleName { get; set; }

    public string RoleId { get; set; }

    public string[] AddIds { get; set; }

    public string[] RemoveIds { get; set; }
}