﻿using System;
using System.Collections.Generic;
using System.Text;
using Catel.MVVM;

namespace Company.Base.Core
{
    public interface IModule
    {
        IconAlias Logo { get; }
        string Name { get; }

        InoModelBase1 HomeModel { get; }
    }
}
