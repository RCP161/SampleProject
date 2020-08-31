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
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Presentation
{
    public class UserOverviewVm : InoViewModelBase1<UserOverview>
    {
        public UserOverviewVm()
        {
            Model = new UserOverview();
            NewUserCommand = new Command(() => NewUser());
            DeleteUserCommand = new Command(() => DeleteUser());
            EditCommand = new Command(() => EditUser());


            SelectedUser = Users.FirstOrDefault();
        }

        #region Properties

        [ViewModelToModel]
        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));


        public User SelectedUser
        {
            get { return GetValue<User>(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }
        public static readonly PropertyData SelectedUserProperty = RegisterProperty(nameof(SelectedUser), typeof(User));


        public Command NewUserCommand { get; private set; }
        public Command DeleteUserCommand { get; private set; }
        public Command EditCommand { get; private set; }

        #endregion

        #region Methods

        private void NewUser()
        {
            SelectedUser = new User();
            SelectedUser.SetState(StateEnum.Created);
            SelectedUser.IsOnEdit = true;
        }

        private void DeleteUser()
        {
            ServiceLocator.Default.ResolveType<IUserService>().DeleteUser(SelectedUser);
            Users.Remove(SelectedUser);
            SelectedUser = Users.FirstOrDefault();
        }

        private void EditUser()
        {
            SelectedUser.IsOnEdit = true;
        }

        #endregion
    }
}
