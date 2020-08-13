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
    public class GroupRepository : InoBaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Group> GetAllComplete()
        {
            return GetQuery().Include(x => x.GroupUsers).Include(x => x.GroupPermissions).ToList();
        }

        public IEnumerable<Group> GetByUserId(long id)
        {
            return GetQuery(x => x.GroupUsers.Any(gu => gu.User.Id == id)).ToList();
        }

        public IEnumerable<Group> GetForSearchText(string arg)
        {
            return GetQuery(x => x.Name.Contains(arg)).ToList();
        }

        public IEnumerable<Group> GetLast10()
        {
            return GetQuery().OrderByDescending(x => x.Id).Take(10);
        }
    }
}
