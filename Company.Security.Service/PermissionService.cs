using System;
using Company.AppName.Data;
using Company.Base.Service;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class PermissionService : InoBaseService<Permission, IPermissionRepository>, IPermissionService
    {
        public void SavePermission(Permission p)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IPermissionRepository>().SaveOrUpdate(p);
                uow.SaveChanges();
            }

            p.SetState(Base.Core.StateEnum.Unchanged);
        }
    }
}
