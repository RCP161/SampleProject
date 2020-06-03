using System;
using System.Collections.Generic;
using System.Linq;
using Catel.Linq;
using Company.AppName.Data;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Company.Security.Core.Services;
using Orc.EntityFramework;

namespace Company.Security.Service
{
    public class GroupService : IGroupService
    {
        public IEnumerable<Group> GetAll()
        {
            IEnumerable<Group> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>())
            {
                res = uow.GetRepository<IGroupRepository>().GetQuery().ToList();
            }

            return res;
        }

        public void SaveGroup(Group grp)
        {
            throw new NotImplementedException();
        }
    }
}
