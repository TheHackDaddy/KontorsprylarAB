using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class Order
    {
        //TODO NEEDS USER INFO TO TRACK ORDER HISTORY (WHEN IDENTITY FW IS ONLINE)  

        public ShoppingCart OrderedProducts { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address InvoiceAddress { get; set; }

    }
}
