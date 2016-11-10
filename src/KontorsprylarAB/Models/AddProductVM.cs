using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class AddProductVM
    {
        [Required(ErrorMessage = "ArticleNumber is very important.")]
        public string ArticleNumber { get; set; }

        [Required(ErrorMessage = "A man needs a name. So does a product.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yeeeeaas. But how many are there?")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Free, is it?")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "'Tis better to describe than not to.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Put http address to nice picture here, master.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Give categorically a category.")]
        public int Category { get; set; }


    }
}
