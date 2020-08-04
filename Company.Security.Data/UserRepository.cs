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
            return GetQuery().Include(x => x.Groups).ToList();
        }

        public IEnumerable<User> GetByGroupId(long id)
        {
            return GetQuery(x => x.Groups.Any(g => g.Id == id)).ToList();
        }
    }
}
