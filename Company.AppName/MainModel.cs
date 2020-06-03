using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Base.Core;

namespace Company.AppName
{
    public class MainModel : ModelBase1
    {
        public MainModel()
        {
            Modules.Add(new Security.Core.Models.Module());
        }

        public ObservableCollection<IModule> Modules
        {
            get { return GetValue<ObservableCollection<IModule>>(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly PropertyData ModulesProperty = RegisterProperty(nameof(Modules), typeof(ObservableCollection<IModule>), () => new ObservableCollection<IModule>());
    }
}
