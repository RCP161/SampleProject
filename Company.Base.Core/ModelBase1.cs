using System;
using Catel.Data;

namespace Company.Base.Core
{
    public abstract class ModelBase1 : ModelBase
    {
        // Model für alle Darstellungssachen
        public ModelBase1()
        {
            IsReadOnly = true;
            State = StateEnum.Unchanged;
        }

        // Brauche ich hier schon wegen dem State. Kann ja ber default unchanged sein
        [IgnoreOnState]
        public StateEnum State
        {
            get { return GetValue<StateEnum>(StateProperty); }
            internal set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(StateEnum));

        public new bool IsReadOnly
        {
            get { return base.IsReadOnly; }
            internal set { base.IsReadOnly = value; }
        }

        [IgnoreOnState]
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

        #endregion
    }

}