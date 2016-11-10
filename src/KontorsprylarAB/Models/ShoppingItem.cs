using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class ShoppingItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingItem(Product product, int qty)
        {
            Quantity = qty;
            Product = product;
        }
    }
}
