using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Presentation
{
    public class UserRoItemVm : InoViewModelBase1<User>
    {
        public UserRoItemVm(User model)
        {
            Model = model;
        }
    }
}
