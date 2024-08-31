using FreshShop.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.Abstract
{
    public interface ICategoryBs
    {
        List<Category> GetAll(Expression<Func<Category, bool>>? filter = null);
        Category Get(Expression<Func<Category, bool>> filter);
        Category GetById(int id);
        int Insert(Category entity);
        void Update(Category entity);
        void Delete(Category entity);

        
    }
}
