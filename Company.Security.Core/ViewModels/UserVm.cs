using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Security.Core.Models;

namespace Company.Security.Core.ViewModels
{
    public class UserVm : ViewModelBase
    {
        public UserVm(User model)
        {
            Model = model;
        }

        #region Properties

        [Model]
        public User Model
        {
            get { return GetValue<User>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(User));


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


        //public Command OpenGroupCommand { get; private set; }
        //public Command OpenUserCommand { get; private set; }

        #endregion
    }
}
