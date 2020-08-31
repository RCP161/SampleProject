using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Basic.Core.Models;

namespace Company.Basic.Presentation
{
    public class PersonRoItemVm : InoViewModelBase1<Person>
    {
        public PersonRoItemVm(Person model)
        {
            Model = model;
        }
    }
}
