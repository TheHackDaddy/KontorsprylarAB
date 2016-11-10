using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Controllers
{
    public class UserController
    {
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
