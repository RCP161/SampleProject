using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.Reflection;

namespace Company.Base.Core
{
    // Model für alle speicherbaren Objekte

    public abstract class InoModelBase2 : InoModelBase1
    {

        public InoModelBase2()
        { }

        public abstract long Id { get; protected set; }

        [NotMapped]
        public bool IsOnEdit
        {
            get { return GetValue<bool>(IsOnEditProperty); }
            set { SetValue(IsOnEditProperty, value); }
        }
        public static readonly PropertyData IsOnEditProperty = RegisterProperty(nameof(IsOnEdit), typeof(bool));

        [NotMapped]
        public abstract Dictionary<string, PropertyInfo> MappedPropertyInfos { get; }


        #region Methods

        public void SetState(StateEnum state)
        {
            State = state;
        }

        protected override sealed string GetDisplyTextWithState()
        {
            string dpText = GetDisplayText();

            if(State.HasFlag(StateEnum.Modified) || State.HasFlag(StateEnum.Created))
                dpText += "*";

            return dpText;
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(IsOnEdit && State == StateEnum.Unchanged && MappedPropertyInfos.ContainsKey(e.PropertyName))
                State = StateEnum.Modified;
        }

        protected Dictionary<string, PropertyInfo> GetPropertyInfos()
        {
            Dictionary<string, PropertyInfo> res = new Dictionary<string, PropertyInfo>();

            foreach(PropertyInfo pi in GetType().GetProperties())
            {
                if(pi.GetAttribute<NotMappedAttribute>() == null)
                    res.Add(pi.Name, pi);
            }

            return res;
        }

        #endregion
    }
}
