using System;
using System.Data.Entity;
using Company.Base.Core;
using Orc.EntityFramework.Repositories;

namespace Company.Base.Data
{
    public abstract class InoBaseRepository<T> : EntityRepositoryBase<T, long>, IInoBaseRepository<T> where T : InoModelBase2
    {
        private DbContext _context;
        public InoBaseRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
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
                    _context.Entry(model).State = EntityState.Deleted;
                    break;
            }

            // Wenn gelösch, eh egal, nur was, wenn Commit/DB Flush/Go schief geht?
            model.SetState(StateEnum.Unchanged);
        }
    }
}
