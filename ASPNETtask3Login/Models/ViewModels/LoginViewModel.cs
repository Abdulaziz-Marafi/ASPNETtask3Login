using System.ComponentModel.DataAnnotations;

namespace ASPNETtask3Login.Models.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 15 characters")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 15 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
