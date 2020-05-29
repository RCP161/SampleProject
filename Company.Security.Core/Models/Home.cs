using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.Base.Core;
using Company.Security.Core.Services;

namespace Company.Security.Core.Models
{
    public class Home : ModelBase1
    {
        public Home()
        {
            Users = new ObservableCollection<User>(ServiceLocator.Default.ResolveType<IUserService>().GetAll());
            Groups = new ObservableCollection<Group>(ServiceLocator.Default.ResolveType<IGroupService>().GetAll());
        }

        #region Properties

        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));


        public ObservableCollection<Group> Groups
        {
            get { return GetValue<ObservableCollection<Group>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));

        #endregion
    }
}
