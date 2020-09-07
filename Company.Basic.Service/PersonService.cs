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

            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                res = uow.GetRepository<IPersonRepository>().GetAll().ToList();
            }

            return res;
        }

        public Person GetPersonById(long id)
        {
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                return uow.GetRepository<IPersonRepository>().GetByKey(id);
            }
        }

        public void SavePerson(Person person)
        {
            using(DbContextManager<AppDbContext> manager = DbContextManager<AppDbContext>.GetManager())
            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(manager.Context))
            {
                IPersonRepository pr = uow.GetRepository<IPersonRepository>();

                pr.SaveOrUpdate(person);
                uow.SaveChanges();
            }
        }

        public void DeletePerson(Person selectedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
