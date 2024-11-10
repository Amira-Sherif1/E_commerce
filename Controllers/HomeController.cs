using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Reposetory.IReposetory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        // ApplicationDbContext dbcontext = new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;
        ICategoryReposetory CategoryReposetory;
        IProductReposetory ProductReposetory;
        public HomeController( ICategoryReposetory categoryReposetory, IProductReposetory productReposetory , ILogger<HomeController> logger)
        {
            _logger = logger;

            CategoryReposetory = categoryReposetory;
            ProductReposetory = productReposetory;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
           // var products = dbcontext.Products;
           var products = ProductReposetory.GetAll();
            return View(model : products);
        }
        public IActionResult Details(int productid)
        {
            // var product = dbcontext.Products.Find(productid);
            var product = ProductReposetory.GetOne(e=>e.Id==productid);
            if (product != null)
            {
                return View(model: product);

            }
            else
            {
                return RedirectToAction(nameof(NotFoundPage));
            }
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
