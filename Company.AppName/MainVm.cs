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

            ActivCommand = new Command<InoModelBase1>(SetActivatedModule);
        }

        #region Properties

        [Model]
        public MainModel Model
        {
            get { return GetValue<MainModel>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(MainModel));


        public Command<InoModelBase1> ActivCommand { get; private set; }


        [ViewModelToModel]
        public ObservableCollection<IModule> Modules
        {
            get { return GetValue<ObservableCollection<IModule>>(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly PropertyData ModulesProperty = RegisterProperty(nameof(Modules), typeof(ObservableCollection<IModule>));


        [ViewModelToModel]
        public InoModelBase1 SelectedHomeModel
        {
            get { return GetValue<InoModelBase1>(SelectedHomeModuleProperty); }
            set { SetValue(SelectedHomeModuleProperty, value); }
        }
        public static readonly PropertyData SelectedHomeModuleProperty = RegisterProperty(nameof(SelectedHomeModel), typeof(InoModelBase1));

        #endregion

        #region Methods

        private void SetActivatedModule(InoModelBase1 newActivVm)
        {
            SelectedHomeModel = newActivVm;
        }

        #endregion

    }
}
