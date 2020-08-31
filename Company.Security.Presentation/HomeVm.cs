using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class HomeVm : InoViewModelBase1<Home>
    {
        public HomeVm()
        {
            Model = new Home();
        }

    }
}
