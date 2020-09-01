using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class PersonOverviewVm : InoViewModelBase1<PersonOverview>
    {
        public PersonOverviewVm()
        {
            Model = new PersonOverview();
            SelectedPerson = Persons.FirstOrDefault();

            NewPersonCommand = new Command(() => NewPerson());
            DeletePersonCommand = new Command(() => DeletePerson());
            EditCommand = new Command(() => EditPerson());
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


        public Command NewPersonCommand { get; private set; }
        public Command DeletePersonCommand { get; private set; }
        public Command EditCommand { get; private set; }

        #endregion


        private void NewPerson()
        {
            SelectedPerson = new Person();
            SelectedPerson.SetState(StateEnum.Created);
            EditManager.IsOnEdit = true;
        }

        private void DeletePerson()
        {
            ServiceLocator.Default.ResolveType<IPersonService>().DeletePerson(SelectedPerson);
            Persons.Remove(SelectedPerson);
            SelectedPerson = Persons.FirstOrDefault();
        }

        private void EditPerson()
        {
            EditManager.IsOnEdit = true;
        }
    }
}
