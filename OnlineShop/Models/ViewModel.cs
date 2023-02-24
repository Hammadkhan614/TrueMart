using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ViewModel
    {
        public List<Category> Category { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public List<Product> Product { get; set; }
        public List<Brands> Brand { get; set; }

    }
}