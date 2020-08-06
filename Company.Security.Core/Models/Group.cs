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
    [Table("Sec_Group")]
    public class Group : InoModelBase2
    {
        public Group()
        {
            GroupPermissions = new ObservableCollection<GroupPermission>();
            GroupUsers = new ObservableCollection<GroupUser>();
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


        public ObservableCollection<GroupUser> GroupUsers
        {
            get { return GetValue<ObservableCollection<GroupUser>>(GroupUsersProperty); }
            set { SetValue(GroupUsersProperty, value); }
        }
        public static readonly PropertyData GroupUsersProperty = RegisterProperty(nameof(GroupUsers), typeof(ObservableCollection<GroupUser>));

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
