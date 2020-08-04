using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;
using Company.Basic.Core.Models;

namespace Company.Basic.Core.ViewModels
{
    public class PersonVm : InoViewModelBase2<Person>
    {
        public PersonVm(Person model)
        {
            Model = model;
        }


        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public string Surename
        {
            get { return GetValue<string>(SurenameProperty); }
            set { SetValue(SurenameProperty, value); }
        }
        public static readonly PropertyData SurenameProperty = RegisterProperty(nameof(Surename), typeof(string));
    }
}
