﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Basic.Core.Models;

namespace Company.Basic.Presentation
{
    public class HomeVm : InoViewModelBase1<Home>
    {
        public HomeVm()
        {
            Model = new Home();
        }
    }
}
