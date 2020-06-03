using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;
using Company.Security.Core.ViewModels;

namespace Company.AppName
{
    public class MainVm : ViewModelBase
    {
        public MainVm()
        {
            Model = new MainModel();

            SelectedModuleVm = new HomeVm();
        }


        [Model]
        public MainModel Model
        {
            get { return GetValue<MainModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(MainModel));


        [ViewModelToModel]
        public ObservableCollection<IModule> Modules
        {
            get { return GetValue<ObservableCollection<IModule>>(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly PropertyData ModulesProperty = RegisterProperty(nameof(Modules), typeof(ObservableCollection<IModule>));


        public ViewModelBase SelectedModuleVm
        {
            get { return GetValue<ViewModelBase>(SelectedModuleVmProperty); }
            set { SetValue(SelectedModuleVmProperty, value); }
        }
        public static readonly PropertyData SelectedModuleVmProperty = RegisterProperty(nameof(SelectedModuleVm), typeof(ViewModelBase));
    }
}
