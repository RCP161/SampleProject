using System;
using System.Collections.Generic;
using System.Text;
using Company.Security.Core.Models;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Core.Repositories
{
    public interface IUserRepository : IEntityRepository<User, long>
    {
    }
}
