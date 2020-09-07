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
            // Besser EF Core/7 mit IncludeThen!
            // return GetQuery().Include(x => x.GroupUsers).Include("GroupUsers.User").Include(x => x.GroupPermissions).Include("GroupPermissions.Permission").ToList();
            return  GetQuery().Include(x => x.GroupUsers.Select(gu => gu.User)).Include(x => x.GroupPermissions.Select(gp => gp.Permission)).ToList();
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
            return GetQuery().OrderByDescending(x => x.Id).Take(10).ToList();
        }
    }
}
