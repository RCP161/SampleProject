using System;
using System.Collections.Generic;
using System.Text;

namespace Company.AppName.Data
{

    public interface IDbConfigruation
    {
        string ConnectionString { get; }
        bool IsDbLoggingActiv { get; }
        bool CreateNewDb { get; }
    }
}
