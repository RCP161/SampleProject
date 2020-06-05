using System;
using System.Collections.Generic;
using System.Linq;
using Company.AppName.Data;
using Company.Basic.Core.Models;
using Company.Basic.Core.Repositories;
using Company.Basic.Core.Services;
using Orc.EntityFramework;

namespace Company.Basic.Service
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<IPersonRepository>().GetQuery().ToList();
            }

            return res;
        }

        public Person GetPersonById(long id)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                IPersonRepository pr = uow.GetRepository<IPersonRepository>();

                return pr.GetByKey(id);
            }
        }

        public void SavePerson(Person person)
        {
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                IPersonRepository pr = uow.GetRepository<IPersonRepository>();

                pr.Add(person);
                uow.SaveChanges();
            }

            person.SetState(Base.Core.StateEnum.Unchanged);
        }
    }
}
