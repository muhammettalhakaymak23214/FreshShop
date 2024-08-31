using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshShop.Model.Entity;

namespace FreshShop.DataAccess.Abstract
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Manager Login(string userName , string password); 
        Manager GetByEmail (string email);
    }
}
