using FreshShop.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshShop.Model.Entity;
using FreshShop.DataAccess.Abstract;
using Azure.Identity;

namespace FreshShop.DataAccess.Concrete
{
    public class ManagerRepository : RepositoryBase<Manager, FreshShopDbContext>, IManagerRepository
    {
        public Manager Login(string userName, string password)
        {
            return Get(x => (x.UserName == userName) && (x.Password == password));
        }

        public Manager GetByEmail(string email) 
        {
            return Get(x=>x.Email == email);
            
        }
    }
}
