using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Core.ViewModels
{
    public class HomeVm : InoViewModelBase1<Home>
    {
        public HomeVm()
        {
            Model = Home.Instance;
            NewGroupCommand = new Command(() => NewGroup());
            DeleteGroupCommand = new Command(() => DeleteGroup());
            NewUserCommand = new Command(() => NewUser());
            DeleteUserCommand = new Command(() => DeleteUser());

            SelectedUser = Users.FirstOrDefault();
            SelectedGroup = Groups.FirstOrDefault();
        }

        #region Properties

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


        public Command NewGroupCommand { get; private set; }
        public Command DeleteGroupCommand { get; private set; }
        public Command NewUserCommand { get; private set; }
        public Command DeleteUserCommand { get; private set; }

        #endregion

        #region Methods

        private void NewGroup()
        {
            SelectedGroup = new Group();
            SelectedGroup.SetState(StateEnum.Created);
        }

        private void DeleteGroup()
        {
            ServiceLocator.Default.ResolveType<IGroupService>().DeleteGroup(SelectedGroup);
            Groups.Remove(SelectedGroup);
            SelectedGroup = Groups.FirstOrDefault();
        }

        private void NewUser()
        {
            SelectedUser = new User();
            SelectedUser.SetState(StateEnum.Created);
        }

        private void DeleteUser()
        {
            ServiceLocator.Default.ResolveType<IUserService>().DeleteUser(SelectedUser);
            Users.Remove(SelectedUser);
            SelectedUser = Users.FirstOrDefault();
        }

        #endregion
    }
}
