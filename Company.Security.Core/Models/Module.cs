using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Core.ViewModels;

namespace Company.Security.Core.Models
{
    public class Module : InoModelBase1, IModule
    {
        public Module()
        {
            Logo = "Sec.";
            Name = "Security";
            HomeViewModel = new HomeVm();
        }


        #region Properties

        public string Logo { get; private set; }
        public string Name { get; private set; }
        public ViewModelBase HomeViewModel { get; private set; }

        #endregion
    }
}
