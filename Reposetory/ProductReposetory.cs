using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Reposetory.IReposetory;

namespace E_Commerce.Reposetory
{
    public class ProductReposetory : Reposetory<Product>, IProductReposetory
    {
        private ApplicationDbContext dbcontext;
        public ProductReposetory(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
