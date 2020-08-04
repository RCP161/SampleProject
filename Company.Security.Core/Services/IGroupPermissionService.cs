using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IGroupPermissionService : IInoBaseService<GroupPermission>
    {
        IEnumerable<GroupPermission> GetByGroupId(long id);
    }
}
