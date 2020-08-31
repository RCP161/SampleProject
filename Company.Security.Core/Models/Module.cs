using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    public class Module : InoModelBase1, IModule
    {
        public Module()
        {
            Logo = IconAlias.SecurityLogo;
            Name = "Security";
        }


        #region Properties

        public IconAlias Logo { get; private set; }
        public string Name { get; private set; }

        #endregion
    }
}
