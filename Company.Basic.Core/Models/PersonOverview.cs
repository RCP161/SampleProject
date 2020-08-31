using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.Base.Core;
using Company.Basic.Core.Services;

namespace Company.Basic.Core.Models
{
    public class PersonOverview : InoModelBase1
    {
        public PersonOverview()
        {
            Persons = new ObservableCollection<Person>(ServiceLocator.Default.ResolveType<IPersonService>().GetAll());
        }


        #region Properties

        public ObservableCollection<Person> Persons
        {
            get { return GetValue<ObservableCollection<Person>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Persons), typeof(ObservableCollection<Person>));

        #endregion

    }
}
