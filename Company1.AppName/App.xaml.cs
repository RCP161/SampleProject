namespace Company1.AppName
{
    using System.Windows;

    using Catel.IoC;
    using Catel.Logging;
    using Catel.MVVM;
    using Catel.Reflection;
    using Catel.Services;
    using Catel.Windows;
    using Orchestra.Services;
    using Orchestra.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog _log = LogManager.GetCurrentClassLogger();


        protected override void OnStartup(StartupEventArgs e)
        {

            bool isLogging = false;

            LogManager.IsDebugEnabled = isLogging;
            LogManager.IsStatusEnabled = isLogging;
            LogManager.IsInfoEnabled = isLogging;
            LogManager.IsWarningEnabled = isLogging;
            LogManager.IsErrorEnabled = isLogging;

            if(LogManager.IsDebugEnabled.HasValue && LogManager.IsDebugEnabled.Value)
                LogManager.AddDebugListener();

            _log.Info("Starting application");

            // Want to improve performance? Uncomment the lines below. Note though that this will disable
            // some features. 
            //
            // For more information, see http://docs.catelproject.com/vnext/faq/performance-considerations/

            // Log.Info("Improving performance");
            // Catel.Windows.Controls.UserControl.DefaultCreateWarningAndErrorValidatorForViewModelValue = false;
            // Catel.Windows.Controls.UserControl.DefaultSkipSearchingForInfoBarMessageControlValue = true;

            // TODO: Register custom types in the ServiceLocator
            //Log.Info("Registering custom types");
            //var serviceLocator = ServiceLocator.Default;
            //serviceLocator.RegisterType<IMyInterface, IMyClass>();

            // To auto-forward styles, check out Orchestra (see https://github.com/wildgums/orchestra)
            // StyleHelper.CreateStyleForwardersForDefaultStyles();

            _log.Info("Calling base.OnStartup");


            Register();

            if(ServiceLocator.Default.ResolveType<Company.AppName.Data.IDbConfigruation>().CreateNewDb)
                new TestData();


            IServiceLocator serviceLocator = ServiceLocator.Default;
            IShellService shellService = serviceLocator.ResolveType<IShellService>();
            shellService.CreateAsync<ShellWindow>();

            base.OnStartup(e);
        }

        private void Register()
        {
            // =========================
            //        Services  
            // =========================

            ServiceLocator.Default.RegisterType<Company.AppName.Data.IDbConfigruation, Config>(RegistrationType.Singleton);
            ServiceLocator.Default.RegisterType<Company.Base.Core.ISearchService, SearchDialog.SearchService>(RegistrationType.Transient);

            // Basic

            ServiceLocator.Default.RegisterType<Company.Basic.Core.Repositories.IPersonRepository, Company.Basic.Data.PersonRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Basic.Core.Services.IPersonService, Company.Basic.Service.PersonService>(RegistrationType.Transient);

            // Security

            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IGroupRepository, Company.Security.Data.GroupRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IPermissionRepository, Company.Security.Data.PermissionRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IGroupUserRepository, Company.Security.Data.GroupUserRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IGroupPermissionRepository, Company.Security.Data.GroupPermissionRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IUserRepository, Company.Security.Data.UserRepository>(RegistrationType.Transient);

            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IGroupService, Company.Security.Service.GroupService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IPermissionService, Company.Security.Service.PermissionService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IUserService, Company.Security.Service.UserService>(RegistrationType.Transient);

            // =========================
            //         ViewModels  
            // =========================
            IViewModelLocator viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();

            viewModelLocator.Register(typeof(Views.MainView), typeof(ViewModels.MainViewModel));
            viewModelLocator.Register(typeof(SearchDialog.SearchWindow), typeof(SearchDialog.SearchWindowViewModel));

            // Basic
            viewModelLocator.Register(typeof(Company.Basic.UI.HomeView), typeof(Company.Basic.Presentation.HomeVm));
            viewModelLocator.Register(typeof(Company.Basic.UI.PersonView), typeof(Company.Basic.Presentation.PersonVm));

            // Security
            viewModelLocator.Register(typeof(Company.Security.UI.HomeView), typeof(Company.Security.Presentation.HomeVm));
            viewModelLocator.Register(typeof(Company.Security.UI.GroupView), typeof(Company.Security.Presentation.GroupVm));
            viewModelLocator.Register(typeof(Company.Security.UI.GroupRoItemView), typeof(Company.Security.Presentation.GroupRoItemVm));
            viewModelLocator.Register(typeof(Company.Security.UI.UserView), typeof(Company.Security.Presentation.UserVm));
            viewModelLocator.Register(typeof(Company.Security.UI.UserRoItemView), typeof(Company.Security.Presentation.UserRoItemVm));

            // =========================
            //          Views  
            // =========================

            IViewLocator viewLocator = ServiceLocator.Default.ResolveType<IViewLocator>();

            // Basic
            viewLocator.Register(typeof(Company.Basic.Presentation.HomeVm), typeof(Company.Basic.UI.HomeView));

            // Security
            viewLocator.Register(typeof(Company.Security.Presentation.HomeVm), typeof(Company.Security.UI.HomeView));

            // =========================
            //        Windows  
            // =========================

            IUIVisualizerService uIVisualizerService = ServiceLocator.Default.ResolveType<IUIVisualizerService>();

            uIVisualizerService.Register(typeof(ViewModels.MainViewModel), typeof(Views.MainView));
            uIVisualizerService.Register(typeof(SearchDialog.SearchWindowViewModel), typeof(SearchDialog.SearchWindow));
        }

        // TODO : Todo-Liste

        // SonarQube warnung wenn auf NotMapped eigenschaften im Repo zugegriffen werden?


        // Weitere Themen
        // DeleteCascade ist im EF immer an. Austellen ist derzeit nicht möglich. Sollte man aber noch mit größerer Modelanzahl testen
        // Klassen halten eine ClassInfo, die die Relection Informationen enthält, für Validierung, ...
        // Auf Close Methode von Model/Vm hören und Dirty(State) überprüfen

        // Optimierungen
        // - Ef:                    Concurrency + MergeDialog (könnte fehlerhafte programmierung/refreshing aufdecken)
        // - ReadOnlyVms:           ReadOnly Properties an VMs prüfen
        // - Namesnkonvention:      Locator (service, ViewModel, ...) über Namesnkonvention regeln


        // PR:
        // Brauche ich ModelBase1 überhaupt noch?
        // Doch ein eigenes BaseRepo dazwischen hängen zum speichern
        // Keine EF Plus unterstützung
        // Repo UnitTest durch TestDB machen?
        // ModulCache der spezifische Daten im Ram hält/freigibt (Spracheinträge, Objektinfos, etc)


        // Mögliche Erweiterungen
        // - Instanz refresher:     2 Instanzen des selben Datensatzes refreshen, nach Speichern
        // - Validation https://codingfreaks.de/wpf-mvvm-03/
        // - PropertyGrid?
        // - Mehrsprachenfähigkeit - https://docs.catelproject.com/5.1/catel-core/multilingual/
        // - Schreibrechte abprüfen
        // - EF Plus prüfen
        // - CodeGeneration
        //   - EF DB Sets
        //   - Respository
        //   - Service (Logic)
        //   - VM
        //   - View



        //  Prio    Tool                    Link                                                        Zweck                       Alternative         Link
        //  3	    Orc.AutomaticSupport    https://opensource.wildgums.com/orc.automaticsupport/	    Downloader?		
        //  1   	Orc.Controls            https://opensource.wildgums.com/orc.controls/	            Controls	                Xceed	
        //  2   	Orc.Csv                 https://opensource.wildgums.com/orc.csv/ 	                CSV Export		
        //  1	    Orc.EntityFramework     https://opensource.wildgums.com/orc.entityframework/	    EF mit Models handeln		
        //  1	    Orc.Extensibility       https://opensource.wildgums.com/orc.extensibility/	        Moule Configurieren & Laden		
        //  3   	Orc.Feedback            https://opensource.wildgums.com/orc.feedback/	            Feedback von Enduser		
        //  2   	Orc.FileSystem          https://opensource.wildgums.com/orc.filesystem/	            Dateizugriffe 		
        //  3   	Orc.FilterBuilder       https://opensource.wildgums.com/orc.filterbuilder/	        DatenFilter		
        //  2	    Orc.FluentValidation    https://opensource.wildgums.com/orc.fluentvalidation/	    Validierung	                IDataError	        https://codingfreaks.de/wpf-mvvm-03/
        //  2	    Orc.LicenseManager      https://opensource.wildgums.com/orc.licensemanager/     	Lizenzen		
        //  2   	Orc.LogViewer           https://opensource.wildgums.com/orc.logviewer/	            LogViwer	                Yalv	
        //  1   	Orc.Memento             https://opensource.wildgums.com/orc.memento/	            Undo/Redo		
        //  2   	Orc.Metadata            https://opensource.wildgums.com/orc.metadata/	            Meta-Daten über Objekte (für Validation?)		
        //  3   	Orc.Notifications       https://opensource.wildgums.com/orc.notifications/	        Notifications		
        //  3   	Orc.Plot                https://opensource.wildgums.com/orc.plot/	                Erweitert OxyPlot		
        //  3   	Orc.Scheduling          https://opensource.wildgums.com/orc.scheduling/	            Wiederkehrende Aufgaben		
        //          Orc.SelectionManagement https://opensource.wildgums.com/orc.selectionmanagement/	?		
        //  3	    Orc.Snapshots           https://opensource.wildgums.com/orc.snapshots/	            Screenshot		
        //  2	    Orc.Squirrel            https://opensource.wildgums.com/orc.squirrel/	            Updater		
        //  2	    Orc.SupportPackage      https://opensource.wildgums.com/orc.squirrel/	            SupportPackage		
        //  2	    Orc.SystemInfo          https://opensource.wildgums.com/orc.systeminfo/	            Systeminfo		
        //  2	    Orc.Wizard              https://opensource.wildgums.com/orc.wizard/	                Wizard/Assistent	        Xceed	

        //          Math.NET                https://numerics.mathdotnet.com/Integration.html
        //          weitere Tools           https://github.com/quozd/awesome-dotnet	
    }
}