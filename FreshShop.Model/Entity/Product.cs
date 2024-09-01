using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Entity
{
    public class Product : BaseEntity
    {
        public Product() {
            Photos = new HashSet<ProductPhoto>();
            Comments = new HashSet<ProductComment>();

        }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public string? ShortDesciription { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductPhoto> Photos { get; set; }
        public virtual ICollection<ProductComment> Comments { get; set; }




    }
}
