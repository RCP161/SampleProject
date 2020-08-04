using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IGroupService : IInoBaseService<Group>
    {
        IEnumerable<Group> GetByUserId(long id);
        IEnumerable<Group> GetAllComplete();
        void SaveGroup(Group model);
    }
}
