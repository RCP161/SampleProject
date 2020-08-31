using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Core.Services;

namespace Company.Security.Core.Models
{
    public class UserOverview : InoModelBase1
    {
        public UserOverview() : base()
        {
            Users = new ObservableCollection<User>(ServiceLocator.Default.ResolveType<IUserService>().GetAllComplete());
        }

        #region Properties

        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));

        #endregion
    }
}
