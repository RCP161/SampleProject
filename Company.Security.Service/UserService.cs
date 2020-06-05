using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Company.AppName.Data;
using Company.Base.Service;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class UserService : ModelBase2Service<User, IUserRepository>, IUserService
    {
        //public IEnumerable<User> GetAll()
        //{
        //    IEnumerable<User> res;
        //    using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
        //    {
        //        res = uow.GetRepository<IUserRepository>().GetAll().ToList();
        //    }

        //    return res;
        //}

        public IEnumerable<User> GetAllComplete()
        {
            IEnumerable<User> res;
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IUserRepository>().GetAll().Include(x => x.Groups).ToList();
            }

            return res;
        }

        public IEnumerable<User> GetByGroupId(long id)
        {
            IEnumerable<User> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IUserRepository>().GetQuery(x => x.Groups.Any(g => g.Id == id)).ToList();
            }

            return res;
        }

        //public void SaveUser(User user)
        //{
        //    using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
        //    {
        //        IUserRepository ur = uow.GetRepository<IUserRepository>();

        //        ur.Add(user);
        //        uow.SaveChanges();
        //    }

        //    user.SetState(Base.Core.StateEnum.Unchanged);
        //}
    }
}
