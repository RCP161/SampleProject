using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Company.Base.Data;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Data
{
    public class UserRepository : InoBaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> GetAllComplete()
        {
            return GetQuery().Include(x => x.GroupUsers).ToList();
        }

        public IEnumerable<User> GetByGroupId(long id)
        {
            return GetQuery(x => x.GroupUsers.Any(gu => gu.Group.Id == id)).ToList();
        }

        public IEnumerable<User> GetForSearchText(string arg)
        {
            return GetQuery(x => x.LogIn.Contains(arg)).ToList();
        }

        public IEnumerable<User> GetLast10()
        {
            return GetQuery().OrderByDescending(x => x.Id).Take(10);
        }
    }
}
