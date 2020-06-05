using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Security.Core.Models;

namespace Company.Security.Core.ViewModels
{
    public class GroupVm : ViewModelBase
    {
        public GroupVm(Group model)
        {
            Model = model;
            SaveCommand = new Command(Model.Save);
            CancelCommand = new Command(Cancel);
        }

        #region Properties

        [Model]
        public Group Model
        {
            get { return GetValue<Group>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Group));


        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public ObservableCollection<GroupPermission> GroupPermissions
        {
            get { return GetValue<ObservableCollection<GroupPermission>>(GroupPermissionsProperty); }
            set { SetValue(GroupPermissionsProperty, value); }
        }
        public static readonly PropertyData GroupPermissionsProperty = RegisterProperty(nameof(GroupPermissions), typeof(ObservableCollection<GroupPermission>));


        public GroupPermission SelectedGroupPermission
        {
            get { return GetValue<GroupPermission>(SelectedGroupPermissionProperty); }
            set { SetValue(SelectedGroupPermissionProperty, value); }
        }
        public static readonly PropertyData SelectedGroupPermissionProperty = RegisterProperty(nameof(SelectedGroupPermission), typeof(GroupPermission));


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


        //public Command OpenGroupCommand { get; private set; }
        //public Command OpenUserCommand { get; private set; }
        public Command SaveCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        #endregion

        #region Methods

        private void Cancel()
        {
            // Siehe UserVm
            //throw new NotImplementedException();
        }

        #endregion
    }
}
