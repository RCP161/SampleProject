using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Base.Core
{
    public interface ISearchService
    {

        Task<T> SearchAsync<T>() where T : InoModelBase2;
        Task<IEnumerable<T>> SearchMultipleAsync<T>() where T : InoModelBase2;
    }
}
