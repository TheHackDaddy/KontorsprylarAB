using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double ListPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Category { get; set; }


    }
}
