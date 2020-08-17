using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Presentation;

namespace Company.Basic.Core.Models
{
    public class Module : InoModelBase1, IModule
    {
        public Module()
        {
            Logo = "Bsc.";
            Name = "Basic";
            HomeModel = Home.Instance;
        }


        #region Properties

        public string Logo { get; private set; }
        public string Name { get; private set; }
        public InoModelBase1 HomeModel { get; private set; }

        #endregion
    }
}
