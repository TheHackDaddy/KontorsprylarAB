using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        public string Index()
        {
            return $"You are logged in as {User.Identity.Name}";
        }


    }
}
