using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Core.ViewModels
{
    public class UserVm : InoViewModelBase2<User>
    {
        public UserVm(User model)
        {
            Model = model;
            SaveCommand = new Command(() => SaveUser()); 
            CancelCommand = new Command(Revert);
        }

        #region Properties

        [ViewModelToModel]
        public string LogIn
        {
            get { return GetValue<string>(LogInProperty); }
            set { SetValue(LogInProperty, value); }
        }
        public static readonly PropertyData LogInProperty = RegisterProperty(nameof(LogIn), typeof(string));


        [ViewModelToModel]
        public ObservableCollection<Group> Groups
        {
            get { return GetValue<ObservableCollection<Group>>(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly PropertyData GroupsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));


        public Group SelectedGroup
        {
            get { return GetValue<Group>(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }
        public static readonly PropertyData SelectedGroupProperty = RegisterProperty(nameof(SelectedGroup), typeof(Group));


        public Command SaveCommand { get; private set; }
        public Command CancelCommand { get; private set; }
        //public Command OpenGroupCommand { get; private set; }
        //public Command OpenUserCommand { get; private set; }

        #endregion

        #region Methods

        private void SaveUser()
        {
            bool isNew = Model.State == StateEnum.Created;
            ServiceLocator.Default.ResolveType<IUserService>().SaveUser(Model);

            if(isNew)
                Home.Instance.Users.Add(Model);
        }

        #endregion
    }
}
