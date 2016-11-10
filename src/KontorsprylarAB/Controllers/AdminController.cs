using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KontorsprylarAB.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KontorsprylarAB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext identityContext;

        public AdminController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext identityContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.identityContext = identityContext;
        }

        [AllowAnonymous]
        public string Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return $"You are logged in as {User.Identity.Name}";
            }
            else
            {
                return "You are not logged in.";
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Skapa DB-schemat
            //await identityContext.Database.EnsureCreatedAsync();

            // Create user
            //var user = new IdentityUser("admin");
            //var result = await userManager.CreateAsync(user, "Pencil69!");

            var result = await signInManager.PasswordSignInAsync(
                viewModel.Username, viewModel.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(AccountLoginVM.Username),
                    "Incorrect login credentials");
                return View(viewModel);
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction(nameof(AdminController.Index));
            else
                return Redirect(returnUrl);
        }
    }
}
