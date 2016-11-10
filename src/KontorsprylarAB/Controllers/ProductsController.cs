using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KontorsprylarAB.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public IActionResult View(int id)
        {
            return View(DataBaseTools.GetSpecifiedProduct(id));
        }

        public IActionResult Products(int id)
        {
            return View(DataBaseTools.GetAllProducts(id));
        }

    }
}
