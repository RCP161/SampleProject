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
    public class GroupPermissionRepository : InoBaseRepository<GroupPermission>, IGroupPermissionRepository
    {
        public GroupPermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<GroupPermission> GetByGroupId(long id)
        {
            return GetQuery(x => x.Group.Id == id).ToList();
        }
    }
}
