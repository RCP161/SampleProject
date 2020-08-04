using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;
using Orc.EntityFramework.Repositories;

namespace Company.Security.Core.Repositories
{
    public interface IGroupRepository : IInoBaseRepository<Group>
    {
        IEnumerable<Group> GetAllComplete();
        IEnumerable<Group> GetByUserId(long id);
    }
}
