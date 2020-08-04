using System;
using System.Collections.Generic;
using System.Text;
using Orc.EntityFramework.Repositories;

namespace Company.Base.Core
{
    public interface IInoBaseRepository<T> : IEntityRepository<T, long> where T : InoModelBase2
    {
        void SaveOrUpdate(T model);
    }
}
