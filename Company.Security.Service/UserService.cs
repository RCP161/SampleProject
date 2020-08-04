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
    public class UserService : InoBaseService<User, IUserRepository>, IUserService
    {
        public IEnumerable<User> GetAllComplete()
        {
            IEnumerable<User> res;
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IUserRepository>().GetAllComplete();
            }

            return res;
        }

        public IEnumerable<User> GetByGroupId(long id)
        {
            IEnumerable<User> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IUserRepository>().GetByGroupId(id);
            }

            return res;
        }

        public void SaveUser(User user)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IUserRepository>().SaveOrUpdate(user);
                uow.SaveChanges();
            }

            user.SetState(Base.Core.StateEnum.Unchanged);
        }
    }
}
