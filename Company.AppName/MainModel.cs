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
    public class MainModel : InoModelBase1
    {
        public MainModel()
        {
            Modules.Add(new Security.Core.Models.Module());
            Modules.Add(new Basic.Core.Models.Module());


            SelectedHomeModel = Modules.FirstOrDefault().HomeModel;
        }

        public ObservableCollection<IModule> Modules
        {
            get { return GetValue<ObservableCollection<IModule>>(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly PropertyData ModulesProperty = RegisterProperty(nameof(Modules), typeof(ObservableCollection<IModule>), () => new ObservableCollection<IModule>());


        public InoModelBase1 SelectedHomeModel
        {
            get { return GetValue<InoModelBase1>(SelectedHomeModuleProperty); }
            set { SetValue(SelectedHomeModuleProperty, value); }
        }
        public static readonly PropertyData SelectedHomeModuleProperty = RegisterProperty(nameof(SelectedHomeModel), typeof(InoModelBase1));
    }
}
