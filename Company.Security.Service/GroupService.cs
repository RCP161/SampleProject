using System;
using System.Collections.Generic;
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
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>())
            {
                return uow.GetRepository<IGroupRepository>().GetAll();
            }
        }
    }
}
