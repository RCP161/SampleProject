using System;
using System.Collections.Generic;
using System.Text;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Presentation;
using Company.Basic.Core.Models;

namespace Company.Basic.Presentation
{
    public class ModuleVm : InoViewModelBase1<Module>
    {
        public ModuleVm(Module model)
        {
            Model = model;
            InitializedCommand = new Command<object>(p => SetSelectedSubModul(p));
        }

        public object SelectedSubModul
        {
            get { return GetValue<object>(SelectedSubModulProperty); }
            set { SetValue(SelectedSubModulProperty, value); }
        }
        public static readonly PropertyData SelectedSubModulProperty = RegisterProperty(nameof(SelectedSubModul), typeof(object));

        public Command<object> InitializedCommand { get; private set; }

        private void SetSelectedSubModul(object p)
        {
            if(SelectedSubModul == null)
                SelectedSubModul = p;
        }
    }
}
