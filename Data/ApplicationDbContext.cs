using E_Commerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Commerce.ViewModel;

namespace E_Commerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        
            var connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Defaultconnection");
            optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<E_Commerce.ViewModel.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        public DbSet<E_Commerce.ViewModel.LoginUserVM> LoginUserVM { get; set; } = default!;
        



    }
}
