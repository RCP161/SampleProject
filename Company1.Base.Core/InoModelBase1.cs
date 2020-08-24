using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.Logging;
using Catel.Reflection;

namespace Company.Base.Core
{
    // Model für alle speicherbaren Objekte

    public abstract class InoModelBase1 : ModelBase
    {
        // Model für alle Darstellungssachen
        public InoModelBase1()
        {
            State = StateEnum.Unchanged;
        }

        // BaseReadOnly Sperrt das Object, nicht die Oberfläche
        [NotMapped]
        public new bool IsReadOnly { get; set; }

        [NotMapped]
        public StateEnum State
        {
            get { return GetValue<StateEnum>(StateProperty); }
            internal set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(StateEnum));


        // TODO : Bei State PropertyChanged auch IsDirty 
        [NotMapped]
        public new bool IsDirty
        {
            get { return State == StateEnum.Unchanged; }
        }

        [NotMapped]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        #region Methods

        protected virtual string GetDisplyTextWithState()
        {
            return GetDisplayText();
        }

        protected virtual string GetDisplayText()
        {
            return ToString();
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(e.PropertyName != nameof(DisplayText))
                DisplayText = GetDisplyTextWithState();
        }



        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            base.OnBeginEdit(e);

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino M: {0} starts edit", GetType()));
        }

        protected override void OnEndEdit(EditEventArgs e)
        {
            base.OnEndEdit(e);

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino M: {0} ends edit", GetType()));
        }

        protected override void OnCancelEdit(EditEventArgs e)
        {
            base.OnCancelEdit(e);

            if(LogManager.IsDebugEnabled.Value)
                Trace.WriteLine(String.Format("Ino M: {0} aborts edit", GetType()));
        }

        #endregion
    }
}
