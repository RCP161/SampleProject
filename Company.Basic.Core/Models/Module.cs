using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;
using Company.Base.Core;
using Company.Basic.Core.ViewModels;

namespace Company.Basic.Core.Models
{
    public class Module : ModelBase1, IModule
    {
        public Module()
        {
            Logo = "Bsc.";
            Name = "Basic";
            HomeViewModel = new HomeVm();
        }


        #region Properties

        public string Logo { get; private set; }
        public string Name { get; private set; }
        public ViewModelBase HomeViewModel { get; private set; }

        #endregion
    }
}
