using System;
using System.Data.Entity;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Data
{
    public class GroupPermissionRepository : EntityRepositoryBase<GroupPermission, long>, IGroupPermissionRepository
    {
        public GroupPermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
