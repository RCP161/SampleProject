using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Basic.Core.Models;
using Company.Basic.Core.Services;

namespace Company.Basic.Presentation
{
    public class PersonEditVm : InoViewModelBase2<Person>
    {
        public PersonEditVm(Person model)
        {
            Model = model;
            SaveCommand = new Command(() => SavePerson());
            CancelCommand = new Command(Revert);
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


        public Command SaveCommand { get; private set; }
        public Command CancelCommand { get; private set; }



        private void SavePerson()
        {
            bool isNew = Model.State == StateEnum.Created;
            ServiceLocator.Default.ResolveType<IPersonService>().SavePerson(Model);

            if(isNew)
                throw new NotImplementedException("Der Liste hinzufügen");
        }
    }
}
