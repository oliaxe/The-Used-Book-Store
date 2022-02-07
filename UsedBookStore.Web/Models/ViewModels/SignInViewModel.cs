using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        [Required(ErrorMessage = "Enter email")]
        [StringLength(100, ErrorMessage = "The email is not valid", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The password has to be minumum 8 characters", MinimumLength = 8)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
