using System.ComponentModel.DataAnnotations;

namespace MuslimFashion.ViewModel
{
    public class CustomerAddWithRegistrationModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        [RegularExpression("^(88)?((011)|(015)|(016)|(017)|(018)|(019)|(013)|(014))\\d{8,8}$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}