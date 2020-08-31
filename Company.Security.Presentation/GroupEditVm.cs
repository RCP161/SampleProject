using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Base.Presentation;
using Company.Security.Core.Models;
using Company.Security.Core.Services;

namespace Company.Security.Presentation
{
    public class GroupEditVm : InoViewModelBase2<Group>
    {
        public GroupEditVm(Group model)
        {
            Model = model;
            SaveCommand = new Command(() => SaveGroup());
            CancelCommand = new Command(Revert);
            AddPermissionCommand = new TaskCommand(() => AddPermissionAsync());
            RemovePermissionCommand = new Command(() => RemovePermission());
            AddUserCommand = new TaskCommand(() => AddUserAsync());
            RemoveUserCommand= new Command(() => RemoveUser());
        }

        #region Properties

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
        public ObservableCollection<GroupUser> GroupUsers
        {
            get { return GetValue<ObservableCollection<GroupUser>>(GroupUsersProperty); }
            set { SetValue(GroupUsersProperty, value); }
        }
        public static readonly PropertyData GroupUsersProperty = RegisterProperty(nameof(GroupUsers), typeof(ObservableCollection<GroupUser>));


        public GroupUser SelectedGroupUser
        {
            get { return GetValue<GroupUser>(SelectedGroupUserProperty); }
            set { SetValue(SelectedGroupUserProperty, value); }
        }
        public static readonly PropertyData SelectedGroupUserProperty = RegisterProperty(nameof(SelectedGroupUser), typeof(GroupUser));


        public Command SaveCommand { get; private set; }
        public Command CancelCommand { get; private set; }
        public TaskCommand AddPermissionCommand { get; private set; }
        public Command RemovePermissionCommand { get; private set; }
        public TaskCommand AddUserCommand { get; private set; }
        public Command RemoveUserCommand { get; private set; }

        #endregion

        #region Methods

        private void SaveGroup()
        {
            bool isNew = Model.State == StateEnum.Created;
            ServiceLocator.Default.ResolveType<IGroupService>().SaveGroup(Model);

            if(isNew)
                throw new NotImplementedException("Der Liste hinzufügen");
        }

        private async Task AddPermissionAsync()
        {
            Permission permission = await ServiceLocator.Default.ResolveType<ISearchService>().SearchAsync<Permission>();

            if(permission == null)
                return;

            if(GroupPermissions.Any(x => x.Permission.Id == permission.Id))
                return;

            GroupPermission groupPermission = new GroupPermission();
            groupPermission.Permission = permission;
            groupPermission.Group = Model;
            groupPermission.SetState(StateEnum.Created);

            GroupPermissions.Add(groupPermission);
        }

        private void RemovePermission()
        {
            SelectedGroupPermission.SetState(StateEnum.Deleted);
        }

        private async Task AddUserAsync()
        {
            User user = await ServiceLocator.Default.ResolveType<ISearchService>().SearchAsync<User>();

            if(user == null)
                return;

            if(GroupUsers.Any(x => x.User.Id == user.Id))
                return;

            GroupUser groupPermission = new GroupUser();
            groupPermission.User = user;
            groupPermission.Group = Model;
            groupPermission.SetState(StateEnum.Created);

            GroupUsers.Add(groupPermission);
        }

        private void RemoveUser()
        {
            SelectedGroupUser.SetState(StateEnum.Deleted);
        }

        #endregion
    }
}
