using System;
using System.Data.Entity;
using Company.Base.Core;
using Orc.EntityFramework.Repositories;

namespace Company.Base.Data
{
    public abstract class InoBaseRepository<T> : EntityRepositoryBase<T, long>, IInoBaseRepository<T> where T : InoModelBase2
    {
        public InoBaseRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void SaveOrUpdate(T model)
        {
            switch(model.State)
            {
                case StateEnum.Created:
                    Add(model);
                    break;
                case StateEnum.Modified:
                    Attach(model);
                    break;
                case StateEnum.Deleted:
                    Delete(model);
                    break;
            }

            // Wenn gelösch, eh egal, nur was, wenn Commit/DB Flush/Go schief geht?
            model.SetState(StateEnum.Unchanged);
        }
    }
}
