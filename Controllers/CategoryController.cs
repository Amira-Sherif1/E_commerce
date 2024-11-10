using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Reposetory.IReposetory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
   
    public class CategoryController : Controller
    {
        ICategoryReposetory categoryReposetory;

        //ApplicationDbContext dbContext = new ApplicationDbContext();
        public CategoryController(ICategoryReposetory categoryReposetory)
        {
            this.categoryReposetory = categoryReposetory;
        }
        public IActionResult Index()
        {
            //var category = dbContext.Categories.ToList();
            var category = categoryReposetory.GetAll();

            return View(category);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            
                //dbContext.Categories.Add(category);
                //dbContext.SaveChanges();
                categoryReposetory.Add(category);
                categoryReposetory.Save();
                return RedirectToAction(nameof(Index));
            
           // return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete(int Id)
        {
            //var category = dbContext.Categories.Find(Id);
            var category = categoryReposetory.GetOne(e=>e.Id==Id);

            //dbContext.Categories.Remove(category);
            categoryReposetory.Delete(category);
            //dbContext.SaveChanges();
            categoryReposetory.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
