using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Company.Base.Data;
using Company.Security.Core.Models;
using Company.Security.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Data
{
    public class GroupUserRepository : InoBaseRepository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
