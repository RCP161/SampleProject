using System;
using System.Data.Entity;
using Company.Base.Data;
using Company.Basic.Core.Models;
using Company.Basic.Core.Repositories;
using Orc.EntityFramework.Repositories;

namespace Company.Basic.Data
{

    public class PersonRepository : InoBaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
