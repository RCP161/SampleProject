using System;
using System.Collections.Generic;
using System.Text;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        void SaveGroup(Group grp);
    }
}
