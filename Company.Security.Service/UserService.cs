using System;
using System.Collections.Generic;
using System.Linq;
using Company.AppName.Data;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class UserService : IUserService
    {
        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> res;
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>())
            {
                res = uow.GetRepository<IUserRepository>().GetAll().ToList();
            }

            return res;
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
