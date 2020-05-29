using System;
using System.Data.Entity;
using Company.Basic.Core.Models;
using Company.Basic.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Basic.Data
{

    public class PersonRepository : EntityRepositoryBase<Person, long>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
