using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FreshShop.Business.Abstract;
using FreshShop.DataAccess.Abstract;
using FreshShop.DataAccess.Concrete;
using FreshShop.Model.Entity;


namespace FreshShop.Business.Concrete
{
    public class ManagerBs : IManagerBs
    {
        private readonly IManagerRepository _repo;
        public ManagerBs(IManagerRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Manager entity)
        {
            _repo.Delete(entity);
        }

        public Manager Get(Expression<Func<Manager, bool>> filter)
        {
            return _repo.Get(filter);
        }

        public List<Manager> GetAll(Expression<Func<Manager, bool>>? filter = null)
        {
            return _repo.GetAll(filter);
        }

        public Manager GetByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }

        public Manager GetById(int id)
        {
            return _repo.GetById(id);
        }

        public int Insert(Manager entity)
        {
            return _repo.Insert(entity);
        }

        public Manager Login(string userName, string password)
        {
            return _repo.Login(userName, password);
        }

        public void Update(Manager entity)
        {
            _repo.Update(entity);
        }
    }
}
