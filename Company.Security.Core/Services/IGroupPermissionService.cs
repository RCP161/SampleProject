using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IGroupPermissionService : IModelBase2Service<GroupPermission>
    {
        IEnumerable<GroupPermission> GetByGroupId(long id);
    }
}
