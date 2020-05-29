﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    [Table("GroupPermissions")]
    public class GroupPermission : ModelBase2
    { 
        #region Properties

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id
        {
            get { return GetValue<int>(IdProperty); }
            protected set { SetValue(IdProperty, value); }
        }
        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int));


        [Required]
        public Permission Permission
        {
            get { return GetValue<Permission>(PermissionProperty); }
            set { SetValue(PermissionProperty, value); }
        }
        public static readonly PropertyData PermissionProperty = RegisterProperty(nameof(Permission), typeof(Permission));


        [Required]
        public Group Group
        {
            get { return GetValue<Group>(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }
        public static readonly PropertyData GroupProperty = RegisterProperty(nameof(Group), typeof(Group));


        [Required]
        public bool Read
        {
            get { return GetValue<bool>(ReadProperty); }
            set { SetValue(ReadProperty, value); }
        }
        public static readonly PropertyData ReadProperty = RegisterProperty(nameof(Read), typeof(bool));


        [Required]
        public bool Write
        {
            get { return GetValue<bool>(WriteProperty); }
            set
            {
                SetValue(WriteProperty, value);

                if(value)
                    Read = value;
            }
        }
        public static readonly PropertyData WriteProperty = RegisterProperty(nameof(Write), typeof(bool));


        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            if(Permission != null)
                return Permission.Name;
            else
                return null;
        }

        #endregion
    }
}
