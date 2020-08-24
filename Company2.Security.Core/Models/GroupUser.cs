using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    [Table("Sec_GroupUser")]
    public class GroupUser : InoModelBase2
    {

        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id
        {
            get { return GetValue<long>(IdProperty); }
            protected set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(long));


        [Required]
        public User User
        {
            get { return GetValue<User>(UserProperty); }
            set { SetValue(UserProperty, value); }
        }
        public static readonly PropertyData UserProperty = RegisterProperty(nameof(User), typeof(User));


        [Required]
        public Group Group
        {
            get { return GetValue<Group>(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }
        public static readonly PropertyData GroupProperty = RegisterProperty(nameof(Group), typeof(Group));

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
            if(Group != null && User != null)
                return String.Format("{0} \\ {1}", Group.Name, User.LogIn);
            else
                return ToString();
        }

        #endregion

    }
}
