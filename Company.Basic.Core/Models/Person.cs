using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Catel.Data;
using Company.Base.Core;

namespace Company.Basic.Core.Models
{
    [Table("Person")]
    public class Person : ModelBase2
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
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [Required, MaxLength(255)]
        public string Surename
        {
            get { return GetValue<string>(SurenameProperty); }
            set { SetValue(SurenameProperty, value); }
        }
        public static readonly PropertyData SurenameProperty = RegisterProperty(nameof(Surename), typeof(string));

        #endregion

        #region Methods

        protected override string GetDisplayText()
        {
            return String.Format("{0}, {1}", Surename, Name);
        }

        #endregion
    }
}
