using System;
using System.Collections.Generic;
using System.Linq;
using Company.AppName.Data;
using Company.Base.Core;
using Orc.EntityFramework;
using Orc.EntityFramework.Repositories;

namespace Company.Base.Service
{
    public abstract class InoBaseService<T, U> : IInoBaseService<T> where T : InoModelBase2 where U : IEntityRepository<T, long>
    {
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<U>().GetAll().ToList();
            }

            return res;
        }

        public T GetById(long id)
        {
            T res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<U>().GetByKey(id);
            }

            return res;
        }

        public int GetCount()
        {
            int res;

            using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
            {
                res = uow.GetRepository<U>().GetQuery().Count();
            }

            return res;
        }

        // Nicht automatisieren! Alles einzeln speichern aufgrund des States ist nicht effektiv
        //
        //public bool SaveOrUpdate(T model)
        //{
        //    using(UnitOfWork<AppDbContext> uow = new UnitOfWork<AppDbContext>(DbContextManager<AppDbContext>.GetManager().Context))
        //    {
        //        U repo = uow.GetRepository<U>();

        //        switch(model.State)
        //        {
        //            case StateEnum.Created:
        //                repo.Add(model);
        //                break;
        //            case StateEnum.Modified:
        //                repo.Attach(model);
        //                break;
        //            case StateEnum.Deleted:
        //                repo.Delete(model);
        //                break;
        //            default:
        //                return true;
        //        }

        //        uow.SaveChanges();

        //        if(model.State != StateEnum.Deleted)
        //            model.SetState(StateEnum.Unchanged);
        //    }

        //    return true;
        //}
    }
}
