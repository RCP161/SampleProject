using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Company.Base.Core;

namespace Company.Base.Presentation
{
    public class EditManager : PropertyChangedNotifier, IEditManager
    {
        public EditManager()
        {
            IsOnNavigation = true;
        }

        private bool _isOnEdit;
        public bool IsOnEdit
        {
            get { return _isOnEdit; }
            set
            {
                if(SetField(ref _isOnEdit, value))
                    IsOnNavigation = !value;
            }
        }

        private bool _isOnNavigation;
        public bool IsOnNavigation
        {
            get { return _isOnNavigation; }
            private set { SetField(ref _isOnNavigation, value); }
        }
    }
}
