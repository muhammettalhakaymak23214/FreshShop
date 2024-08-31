using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshShop.Model.Entity;

namespace FreshShop.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetByPriceRange(decimal minPrice , decimal maxPrice);
    }
}
