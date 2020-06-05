using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Basic.Core.Models;

namespace Company.Basic.Core.ViewModels
{
    public class PersonVm : ViewModelBase
    {
        public PersonVm(Person model)
        {
            Model = model;
        }


        [Model]
        public Person Model
        {
            get { return GetValue<Person>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Person), null);


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
