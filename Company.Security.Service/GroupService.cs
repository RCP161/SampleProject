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

        public void SaveGroup(Group group)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IGroupRepository>().SaveOrUpdate(group);

                IGroupPermissionRepository gpRep = uow.GetRepository<IGroupPermissionRepository>();
                foreach(GroupPermission gp in group.GroupPermissions)
                    gpRep.SaveOrUpdate(gp);

                uow.SaveChanges();
            }

            List<GroupPermission> deletedGroupPermissions = group.GroupPermissions.Where(x => x.State == StateEnum.Deleted).ToList();

            foreach(GroupPermission gp in group.GroupPermissions)
                group.GroupPermissions.Remove(gp);

            List<User> removed = group.GroupPermissions.Where(x => x.State == StateEnum.Deleted).ToList();

            foreach(GroupPermission gp in group.GroupPermissions)
                group.GroupPermissions.Remove(gp);



            group.SetState(StateEnum.Unchanged);
            foreach(GroupPermission gp in group.GroupPermissions)
                gp.SetState(StateEnum.Unchanged);
        }

        public void DeleteGroup(Group group)
        {
            // Kein DeleteAllowed benötigt

            group.SetState(StateEnum.Deleted);

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IGroupRepository>().SaveOrUpdate(group);

                IGroupPermissionRepository gpRep = uow.GetRepository<IGroupPermissionRepository>();
                foreach(GroupPermission gp in group.GroupPermissions)
                {
                    gp.SetState(StateEnum.Deleted);
                    gpRep.SaveOrUpdate(gp);
                }

                uow.SaveChanges();
            }
        }

        public IEnumerable<InoModelBase2> GetLast10()
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetLast10();
            }

            return res;
        }

        public IEnumerable<InoModelBase2> GetForSearchText(string arg)
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetForSearchText(arg);
            }

            return res;
        }
    }
}
