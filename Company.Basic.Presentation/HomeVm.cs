using System;
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
            Model = Home.Instance;
        }

        #region Properties

        [ViewModelToModel]
        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));


        public Person SelectedPerson
        {
            get { return GetValue<Person>(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }
        public static readonly PropertyData SelectedPersonProperty = RegisterProperty(nameof(SelectedPerson), typeof(Person));


        #endregion
    }
}
