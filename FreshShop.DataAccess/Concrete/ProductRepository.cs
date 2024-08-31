using FreshShop.DataAccess.Abstract;
using FreshShop.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshShop.Model.Entity;

namespace FreshShop.DataAccess.Concrete
{
    public class ProductRepository : RepositoryBase<Product, FreshShopDbContext>, IProductRepository
    {
        public List<Product> GetByCategoryId(int categoryId)
        {
            return GetAll(x => x.CategoryId == categoryId);
        }

        public List<Product> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return GetAll(x => (x.Price >= minPrice) && (x.Price <= maxPrice));
        }
    }
}
