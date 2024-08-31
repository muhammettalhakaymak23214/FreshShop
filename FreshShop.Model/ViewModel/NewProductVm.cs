using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.ViewModel
{
    public class NewProductVm
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public string? ShortDescription { get; set; }
    }
}
