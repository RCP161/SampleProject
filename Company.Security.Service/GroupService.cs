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
    public class GroupService : ModelBase2Service<Group, IGroupRepository>, IGroupService
    {
        //public IEnumerable<Group> GetAll()
        //{
        //    IEnumerable<Group> res;

        //    using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
        //    {
        //        res = uow.GetRepository<IGroupRepository>().GetQuery().ToList();
        //    }

        //    return res;
        //}

        public IEnumerable<Group> GetAllComplete()
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetAll().Include(x => x.Users).Include(x => x.GroupPermissions).ToList();
            }

            return res;
        }

        public IEnumerable<Group> GetByUserId(long id)
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IGroupRepository>().GetQuery(x => x.Users.Any(u => u.Id == id)).ToList();
            }

            return res;
        }

        //public void SaveGroup(Group grp)
        //{
        //    using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
        //    {
        //        IGroupRepository gr = uow.GetRepository<IGroupRepository>();

        //        gr.Add(grp);
        //        uow.SaveChanges();
        //    }

        //    grp.SetState(Base.Core.StateEnum.Unchanged);
        //}
    }
}
