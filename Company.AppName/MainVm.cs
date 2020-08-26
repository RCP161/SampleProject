using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Base.Core;

namespace Company.AppName
{
    public class MainVm : ViewModelBase
    {
        public MainVm()
        {
            Model = new MainModel();
            SelectedModul = Modules.FirstOrDefault();
            SetActivatedModule();

            ActivCommand = new Command(() => SetActivatedModule());
        }

        #region Properties

        public Command ActivCommand { get; private set; }


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


        public IModule SelectedModul
        {
            get { return GetValue<IModule>(SelectedModulProperty); }
            set { SetValue(SelectedModulProperty, value); }
        }
        public static readonly PropertyData SelectedModulProperty = RegisterProperty(nameof(SelectedModul), typeof(IModule));


        [ViewModelToModel]
        public InoModelBase1 SelectedHomeModel
        {
            get { return GetValue<InoModelBase1>(SelectedHomeModuleProperty); }
            set { SetValue(SelectedHomeModuleProperty, value); }
        }
        public static readonly PropertyData SelectedHomeModuleProperty = RegisterProperty(nameof(SelectedHomeModel), typeof(InoModelBase1));

        #endregion

        #region Methods

        private void SetActivatedModule()
        {
            SelectedHomeModel = SelectedModul.HomeModel;
        }

        #endregion

    }
}
