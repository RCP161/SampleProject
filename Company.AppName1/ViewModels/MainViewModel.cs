namespace Company.AppName1.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using Company.AppName1.Models;
    using Company.Base.Core;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Model = new MainModel();

            ActivCommand = new Command<InoModelBase1>(SetActivatedModule);
        }


        #region Properties
        public override string Title { get { return "Welcome to Company.AppName1"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets


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

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }

        #endregion
    }
}