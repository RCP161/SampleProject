﻿using System;
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
            Logo =  IconAlias.BasicLogo;
            Name = "Basic";
        }


        #region Properties

        public IconAlias Logo { get; private set; }
        public string Name { get; private set; }

        #endregion
    }
}
