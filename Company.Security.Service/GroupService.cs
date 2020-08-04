using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Catel.Linq;
using Company.AppName.Data;
using Company.Base.Core;
using Company.Base.Service;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class GroupService : InoBaseService<Group, IGroupRepository>, IGroupService
    {

        public IEnumerable<Group> GetAllComplete()
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetAllComplete();
            }

            return res;
        }

        public IEnumerable<Group> GetByUserId(long id)
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetByUserId(id);
            }

            return res;
        }

        public void SaveGroup(Group grp)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IGroupRepository>().SaveOrUpdate(grp);

                IGroupPermissionRepository gpRep = uow.GetRepository<IGroupPermissionRepository>();
                foreach(GroupPermission gp in grp.GroupPermissions)
                    gpRep.SaveOrUpdate(gp);

                uow.SaveChanges();
            }

            grp.SetState(Base.Core.StateEnum.Unchanged);
            foreach(GroupPermission gp in grp.GroupPermissions)
                gp.SetState(Base.Core.StateEnum.Unchanged);
        }
    }
}
