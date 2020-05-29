using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    [Table("User")]
    public class User : ModelBase2
    {
        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id
        {
            get { return GetValue<int>(IdProperty); }
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


        public List<Group> Groups
        {
            get { return GetValue<List<Group>>(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly PropertyData GroupsProperty = RegisterProperty(nameof(Groups), typeof(List<Group>));

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return LogIn;
        }

        #endregion
    }
}
