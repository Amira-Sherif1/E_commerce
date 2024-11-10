using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModel
{
    public class ApplicationUserVM
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }


    }
}
