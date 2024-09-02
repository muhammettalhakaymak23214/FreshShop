using FreshShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.ViewModel
{
    public class ProductVm
    {
        public List<Product> Products { get; set; }

        public List<ProductPhoto> ProductPhoto { get; set; }
    }
}
