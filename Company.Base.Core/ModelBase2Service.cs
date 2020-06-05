using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Core
{
    public interface IModelBase2Service<T> where T : ModelBase2
    {
        T GetById(long id);

        IEnumerable<T> GetAll();

        int GetCount();

        //bool IsDeleteAllowed(T model, IEnumerable<string> conflicts);

        //bool TryDelete(T model, IEnumerable<string> conflicts);

        bool SaveOrUpdate(T model);
    }
}
