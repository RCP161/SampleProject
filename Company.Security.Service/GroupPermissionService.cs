using System;
using System.Collections.Generic;
using System.Linq;
using Company.AppName.Data;
using Company.Base.Service;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class GroupPermissionService : ModelBase2Service<GroupPermission, IGroupPermissionRepository>, IGroupPermissionService
    {
        public IEnumerable<GroupPermission> GetByGroupId(long id)
        {
            IEnumerable<GroupPermission> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupPermissionRepository>().GetQuery(x => x.Group.Id == id).ToList();
            }

            return res;
        }
    }
}
