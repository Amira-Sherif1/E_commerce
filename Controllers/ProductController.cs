using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Reposetory;
using E_Commerce.Reposetory.IReposetory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        // ApplicationDbContext dbcontext = new ApplicationDbContext();
        IProductReposetory productReposetory;
        ICategoryReposetory categoryReposetory;

        public ProductController (IProductReposetory productReposetory , ICategoryReposetory categoryReposetory)
        {
            this.productReposetory = productReposetory;
            this.categoryReposetory = categoryReposetory;
        }

        public IActionResult Index()
        {
            //var products = dbcontext.Products.Include(e=>e.Category).ToList();
            var products = productReposetory.GetAll(e=>e.Category);

            return View(products);
        }
        public IActionResult Add()
        {
            // var category=dbcontext.Categories.ToList();
            var category = categoryReposetory.GetAll();
            return View(category);
        }
        [HttpPost]

        public IActionResult Add(Product product , IFormFile ImgUrl)
        {
            if(ImgUrl.Length > 0)
            {
                var filename= Guid.NewGuid()+Path.GetExtension(ImgUrl.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",filename);
                using(var stream = System.IO.File.Create(filepath))
                {
                    ImgUrl.CopyTo(stream);
                }
                product.ImgUrl = filename;
            }
           // dbcontext.Products.Add(product);
           productReposetory.Add(product);
            // dbcontext.SaveChanges();
            productReposetory.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id )
        {
            //var product = dbcontext.Products.Find(id);
            var product = productReposetory.GetOne(e=>e.Id == id);

            //var categories = dbcontext.Categories.ToList();
            var categories = categoryReposetory.GetAll(); 
            ViewBag.categories = categories;
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product , IFormFile ImgUrl)
        {
       
            //var oldproduct = dbcontext.Products.AsNoTracking().FirstOrDefault(e => e.Id == product.Id);
            var oldproduct=productReposetory.GetOne(e=>e.Id == product.Id);
            if(ImgUrl != null && ImgUrl.Length > 0)
            {
                var filename= Guid.NewGuid() + Path.GetExtension(ImgUrl.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
                //var oldfilepath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images",oldproduct.ImgUrl);
                using (var stream = System.IO.File.Create(filepath))
                {
                    ImgUrl.CopyTo(stream);
                }
                product.ImgUrl = filename;
                //if (System.IO.File.Exists(oldfilepath))
                //{
                //    System.IO.File.Delete(oldfilepath);

                //}
            }
            else
            {
                product.ImgUrl = oldproduct.ImgUrl;

            }
            //dbcontext.Products.Update(product); 
            productReposetory.Edit(product);
            productReposetory.Save();
            //dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            //var product = dbcontext.Products.Find(Id);
            var product = productReposetory.GetOne(e => e.Id == Id);

            var oldfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//upload", product.ImgUrl);
            if (System.IO.File.Exists(oldfilepath))
            {
                System.IO.File.Delete(oldfilepath);

            }
           // dbcontext.Products.Remove(product);
            //dbcontext.SaveChanges();
            productReposetory.Delete(product);
            productReposetory.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
