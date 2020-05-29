using System;
using System.Collections.Generic;
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
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>())
            {
                return uow.GetRepository<IUserRepository>().GetAll();
            }
        }
    }
}
