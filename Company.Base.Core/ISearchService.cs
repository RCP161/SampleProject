using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Core
{
    public interface ISearchService<T> where T : InoModelBase2
    {
        T Search();
        IEnumerable<T> SearchMultiple();
    }
}
