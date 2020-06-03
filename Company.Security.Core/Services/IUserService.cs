using System;
using System.Collections.Generic;
using System.Text;
using Company.Security.Core.Models;

namespace Company.Security.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void SaveUser(User user);
    }
}
