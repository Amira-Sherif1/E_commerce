using E_Commerce.Models;
using E_Commerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }  
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserVM uservm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appuser = new()
                {
                   
                    UserName = uservm.Name,
                    Address = uservm.Address,
                    Email = uservm.Email,

                };
                var result= await userManager.CreateAsync(appuser,uservm.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("password", "The password is invalid");
                }

            }
            return RedirectToAction(nameof(Register)) ;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM loginvm)
        {
            if (ModelState.IsValid)
            { 
                var applicationuser = await userManager.FindByNameAsync(loginvm.Name);

                if (applicationuser != null)
                {
                    var result =  await userManager.CheckPasswordAsync(applicationuser, loginvm.password);
                    if (result)
                    {
                        await signInManager.SignInAsync(applicationuser, loginvm.rememberme);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "invalid password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Name", "username not found");
                }



            }
            return RedirectToAction(nameof (Login)) ;
        }

    }
}
