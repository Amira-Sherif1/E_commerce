using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace E_Commerce.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Address { get; set; }
    }
}
