using System;
using System.Collections.Generic;
using System.Text;
using Company.Basic.Core.Models;
using Orc.EntityFramework.Repositories;

namespace Company.Basic.Core.Repositories
{
    public interface IPersonRepository : IEntityRepository<Person, long>
    {
    }
}
