﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Security.Core.Models
{
    [Table("Permission")]
    public class Permission : ModelBase2
    {

        // IsReadOnly setzen

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


        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return Name;
        }

        #endregion
    }
}
