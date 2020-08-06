using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IPermissionService : IInoBaseService<Permission>
    {
        void SavePermission(Permission p);
        IEnumerable<InoModelBase2> GetLast10();
        IEnumerable<InoModelBase2> GetForSearchText(string arg);
    }
}
