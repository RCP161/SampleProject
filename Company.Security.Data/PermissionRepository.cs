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
    public class PermissionRepository : InoBaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Permission> GetForSearchText(string arg)
        {
            return GetQuery(x => x.Name.Contains(arg)).ToList();
        }

        public IEnumerable<Permission> GetLast10()
        {
            return GetQuery().OrderByDescending(x => x.Id).Take(10);
        }
    }
}
