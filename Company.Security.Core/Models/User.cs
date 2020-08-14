using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.IoC;
using Company.Base.Core;
using Company.Security.Core.Services;

namespace Company.Security.Core.Models
{
    [Table("Sec_User")]
    public class User : InoModelBase2
    {
        public User()
        {
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
        public string LogIn
        {
            get { return GetValue<string>(LogInProperty); }
            set { SetValue(LogInProperty, value); }
        }
        public static readonly PropertyData LogInProperty = RegisterProperty(nameof(LogIn), typeof(string));


        [Required, MaxLength(255)]
        public string Password
        {
            get { return GetValue<string>(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly PropertyData PasswordProperty = RegisterProperty(nameof(Password), typeof(string));


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
            return LogIn;
        }

        #endregion
    }
}
