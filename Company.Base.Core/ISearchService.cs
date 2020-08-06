using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Core
{
    public interface ISearchService
    {
        T Search<T>() where T : InoModelBase2;
        IEnumerable<T> SearchMultiple<T>() where T : InoModelBase2;
    }
}
