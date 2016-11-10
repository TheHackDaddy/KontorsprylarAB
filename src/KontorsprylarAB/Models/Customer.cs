using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class Customer : User
    {
        public List<Product> ShoppingCart { get; set; }
    }
}
