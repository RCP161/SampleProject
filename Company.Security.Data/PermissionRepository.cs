using System;
using System.Data.Entity;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Data
{
    public class PermissionRepository : EntityRepositoryBase<Permission, long>, IPermissionRepository
    {
        public PermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
