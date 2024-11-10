using System.ComponentModel.DataAnnotations;

namespace E_Commerce.ViewModel
{
    public class LoginUserVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberme { get; set; }

    }
}
