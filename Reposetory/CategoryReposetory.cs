using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Reposetory.IReposetory;

namespace E_Commerce.Reposetory
{
    public class CategoryReposetory : Reposetory<Category>, ICategoryReposetory
    {
        private ApplicationDbContext dbcontext;
        public CategoryReposetory(ApplicationDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
