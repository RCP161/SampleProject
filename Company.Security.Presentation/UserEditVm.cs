using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Presentation
{
    public class UserEditVm : InoViewModelBase2<User>
    {
        public UserEditVm(User model)
        {
            Model = model;
            SaveCommand = new Command(() => SaveUser()); 
            CancelCommand = new Command(() => CancelEdition());
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
        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty(nameof(Password), typeof(string));


        [ViewModelToModel]
        public ObservableCollection<GroupUser> GroupUsers
        {
            get { return GetValue<ObservableCollection<GroupUser>>(GroupUsersProperty); }
            set { SetValue(GroupUsersProperty, value); }
        }
        public static readonly PropertyData GroupUsersProperty = RegisterProperty(nameof(GroupUsers), typeof(ObservableCollection<GroupUser>));


        public GroupUser SelectedGroup
        {
            get { return GetValue<GroupUser>(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }
        public static readonly PropertyData SelectedGroupProperty = RegisterProperty(nameof(SelectedGroup), typeof(GroupUser));


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
                throw new NotImplementedException("Der Liste hinzufügen");

            SaveEdition();
        }

        #endregion
    }
}
