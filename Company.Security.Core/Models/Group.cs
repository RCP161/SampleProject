using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.Base.Core;
using Company.Security.Core.Services;

namespace Company.Security.Core.Models
{
    public class Group : InoModelBase2
    {
        public Group()
        {
            GroupPermissions = new ObservableCollection<GroupPermission>();
            Users = new ObservableCollection<User>();
        }

        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id
        {
            get { return GetValue<long>(IdProperty); }
            protected set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(long));


        [Required, MaxLength(255)]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public ObservableCollection<GroupPermission> GroupPermissions
        {
            get { return GetValue<ObservableCollection<GroupPermission>>(GroupPermissionsProperty); }
            set { SetValue(GroupPermissionsProperty, value); }
        }
        public static readonly PropertyData GroupPermissionsProperty = RegisterProperty(nameof(GroupPermissions), typeof(ObservableCollection<GroupPermission>));

        Collection<GrouUserMapp>

        [NotMapped]
        public ObservableCollection<User> Users
        {
            get { return GetValue<ObservableCollection<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(ObservableCollection<User>));

        #endregion

        #region Overrides

        private static Dictionary<string, PropertyInfo> _propertyInfos;
        [NotMapped]
        public override Dictionary<string, PropertyInfo> MappedPropertyInfos
        {
            get
            {
                if(_propertyInfos == null)
                    _propertyInfos = GetPropertyInfos();

                return _propertyInfos;
            }
        }

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}
