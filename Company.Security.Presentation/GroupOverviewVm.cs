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
    public class GroupOverviewVm : InoViewModelBase1<GroupOverview>
    {
        public GroupOverviewVm()
        {
            Model = new GroupOverview();
            NewGroupCommand = new Command(() => NewGroup());
            DeleteGroupCommand = new Command(() => DeleteGroup());

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



        public Command NewGroupCommand { get; private set; }
        public Command DeleteGroupCommand { get; private set; }

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

        #endregion
    }
}
