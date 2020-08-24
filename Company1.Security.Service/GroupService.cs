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
            List<GroupPermission> deletedGroupPermissions = group.GroupPermissions.Where(x => x.State == StateEnum.Deleted).ToList();
            List<GroupUser> removedUsers = group.GroupUsers.Where(x => x.State == StateEnum.Deleted).ToList();

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                uow.GetRepository<IGroupRepository>().SaveOrUpdate(group);

                IGroupPermissionRepository gpRep = uow.GetRepository<IGroupPermissionRepository>();
                foreach(GroupPermission gp in group.GroupPermissions.ToList())
                    gpRep.SaveOrUpdate(gp);


                IGroupUserRepository guRep = uow.GetRepository<IGroupUserRepository>();
                foreach(GroupUser gu in group.GroupUsers.ToList())
                    guRep.SaveOrUpdate(gu);

                uow.SaveChanges();
            }

            foreach(GroupPermission gp in deletedGroupPermissions)
                group.GroupPermissions.Remove(gp);

            foreach(GroupUser gu in removedUsers)
                group.GroupUsers.Remove(gu);
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
