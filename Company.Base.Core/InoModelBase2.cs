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

        /// <summary>
        /// NICHT SETZEN!!! Ist nur für ViewModelBase2. Kann ich so nicht wegkapseln
        /// </summary>
        [NotMapped]
        public bool IsReadyForEdit
        {
            get { return GetValue<bool>(IsReadyForEditProperty); }
            set { SetValue(IsReadyForEditProperty, value); }
        }
        public static readonly PropertyData IsReadyForEditProperty = RegisterProperty(nameof(IsReadyForEdit), typeof(bool));

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

            // IsReadyForEdit weil daran InoViewModelBase2 die geladenen Objekte BackUped etc.
            // IsOnEdit ist nur für UI IsEnabled
            if(IsReadyForEdit && State == StateEnum.Unchanged && MappedPropertyInfos.ContainsKey(e.PropertyName))
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
