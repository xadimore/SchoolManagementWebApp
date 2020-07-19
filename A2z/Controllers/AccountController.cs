using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2z.Library.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace A2z.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
             
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserView registerUser)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerUser.UserName, Email = registerUser.Email };
              var result = await userManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Dashboard", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerUser);
        }



        [HttpPost]
        public async Task<IActionResult> Signout()
        {
           await  signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdminSignin()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> AdminSignin(SignInView model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Dashboard", "Home");
                }

                
                    ModelState.AddModelError(string.Empty, "Invalid Login Details");
               
            }

            return View(model);
        }


        public IActionResult Login()
        {
            return RedirectToAction("AdminSignIn", "Account");
        }
    }
}
