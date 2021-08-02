using System.ComponentModel.DataAnnotations;

namespace GelatoGuide.Areas.Administration.Models.Roles
{
    public class UpdateRoleFormModel
    {
        [Required]
        public string RoleName { get; set; }
 
        public string RoleId { get; set; }
 
        public string[] AddIds { get; set; }
 
        public string[] RemoveIds { get; set; }
    }
}
