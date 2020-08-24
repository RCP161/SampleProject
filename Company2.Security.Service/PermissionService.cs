using System;
using System.Collections.Generic;
using Company.AppName.Data;
using Company.Base.Core;
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
        }

        public IEnumerable<InoModelBase2> GetLast10()
        {
            IEnumerable<Permission> res;
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IPermissionRepository>().GetLast10();
            }

            return res;
        }

        public IEnumerable<InoModelBase2> GetForSearchText(string arg)
        {
            IEnumerable<Permission> res;
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IPermissionRepository>().GetForSearchText(arg);
            }

            return res;
        }
    }
}
