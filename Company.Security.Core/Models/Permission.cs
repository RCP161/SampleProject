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
    public class Permission : InoModelBase2
    {

        // IsReadOnly setzen

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


        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));

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
