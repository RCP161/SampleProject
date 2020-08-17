using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;

namespace Company.Base.Presentation
{
    public abstract class InoViewModelBase1<T> : ViewModelBase where T : InoModelBase1
    {
        [Model]
        public T Model
        {
            get { return GetValue<T>(ModelProperty); }
            protected set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(T));


        [ViewModelToModel]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

    }
}
