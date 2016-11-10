using KontorsprylarAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Controllers
{
    public class UserController : Controller
    {
        IMemoryCache cache;

        public UserController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult ShoppingCart()
        {
            var list = Models.ShoppingCart.GetShoppingCartList(HttpContext);

            return View(list);
        }

        public IActionResult AddToCart()
        {
            var item = new ShoppingItem(DataBaseTools.GetSpecifiedProduct(2), 1);

            Models.ShoppingCart.addToShoppingCart(item, this.HttpContext);

            return Redirect("Index");
        }
    }
}
