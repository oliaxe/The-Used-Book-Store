using System.ComponentModel.DataAnnotations;

namespace UsedBookStore.Web.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(100, ErrorMessage = "The first name has to be minimum 2 letters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(100, ErrorMessage = "The last name has to be minimum 2 letters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The email must be valid")]
        [Required(ErrorMessage = "Enter your email")]
        [StringLength(100, ErrorMessage = "The email must be valid", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The password has to be at least 8 characters", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "The passwords doesn't match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Enter your street")]
        [StringLength(100, ErrorMessage = "The street name has to be minumum 2 letters", MinimumLength = 2)]
        public string StreetName { get; set; }

        [Display(Name = "Postal code")]
        [Required(ErrorMessage = "Enter your postal code")]
        [StringLength(5, ErrorMessage = "The postal code has to be minumum 5 numbers", MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter your city")]
        [StringLength(100, ErrorMessage = "The city name has to be minumum 2 letters", MinimumLength = 2)]
        public string City { get; set; }

    }
}
