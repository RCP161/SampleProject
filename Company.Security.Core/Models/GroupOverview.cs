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
    public class GroupOverview : InoModelBase1
    {
        public GroupOverview() : base()
        {
            Groups = new ObservableCollection<Group>(ServiceLocator.Default.ResolveType<IGroupService>().GetAllComplete());
        }

        #region Properties

        public ObservableCollection<Group> Groups
        {
            get { return GetValue<ObservableCollection<Group>>(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly PropertyData PersonsProperty = RegisterProperty(nameof(Groups), typeof(ObservableCollection<Group>));

        #endregion
    }
}
