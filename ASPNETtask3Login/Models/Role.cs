using System.ComponentModel.DataAnnotations;

namespace ASPNETtask3Login.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Role Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Role Name must be between 3 and 50 characters")]
        public string RoleName { get; set; }
    }
}
