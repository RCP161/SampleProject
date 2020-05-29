using System;
using System.Data.Entity;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Data
{
    public class GroupRepository : EntityRepositoryBase<Group, long>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
