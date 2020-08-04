using System;
using System.Collections.Generic;
using System.Text;
using Company.Base.Core;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IUserService : IInoBaseService<User>
    {
        IEnumerable<User> GetByGroupId(long id);
        IEnumerable<User> GetAllComplete();
        void SaveUser(User user);
    }
}
