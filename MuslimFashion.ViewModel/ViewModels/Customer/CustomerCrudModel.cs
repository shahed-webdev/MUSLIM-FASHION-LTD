using System.ComponentModel.DataAnnotations;

namespace MuslimFashion.ViewModel
{
    public class CustomerCrudModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        [RegularExpression("^(88)?((011)|(015)|(016)|(017)|(018)|(019)|(013)|(014))\\d{8,8}$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}