using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    [Table("Group")]
    public class Group : ModelBase2
    {
        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id
        {
            get { return GetValue<int>(IdProperty); }
            protected set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));


        [Required, MaxLength(255)]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public List<GroupPermission> GroupPermissions
        {
            get { return GetValue<List<GroupPermission>>(GroupPermissionsProperty); }
            set { SetValue(GroupPermissionsProperty, value); }
        }
        public static readonly PropertyData GroupPermissionsProperty = RegisterProperty(nameof(GroupPermissions), typeof(List<GroupPermission>));


        public List<User> Users
        {
            get { return GetValue<List<User>>(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
        public static readonly PropertyData UsersProperty = RegisterProperty(nameof(Users), typeof(List<User>));

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}
