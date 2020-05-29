using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Catel.IoC;
using Catel.Logging;

namespace Company.AppName
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog _log = LogManager.GetCurrentClassLogger();
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddDebugListener();
#endif

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

            base.OnStartup(e);
        }

        private void Register()
        {
            ServiceLocator.Default.RegisterType<Company.AppName.Data.IDbConfigruation, Config>(RegistrationType.Singleton);


            // Basic

            ServiceLocator.Default.RegisterType<Company.Basic.Core.Repositories.IPersonRepository, Company.Basic.Data.PersonRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Basic.Core.Services.IPersonService, Company.Basic.Service.PersonService>(RegistrationType.Transient);

            // Security

            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IGroupRepository, Company.Security.Data.GroupRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IPermissionRepository, Company.Security.Data.PermissionRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IGroupPermissionRepository, Company.Security.Data.GroupPermissionRepository>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Repositories.IUserRepository, Company.Security.Data.UserRepository>(RegistrationType.Transient);

            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IGroupService, Company.Security.Service.GroupService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IPermissionService, Company.Security.Service.PermissionService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IGroupPermissionService, Company.Security.Service.GroupPermissionService>(RegistrationType.Transient);
            ServiceLocator.Default.RegisterType<Company.Security.Core.Services.IUserService, Company.Security.Service.UserService>(RegistrationType.Transient);
        }
    }
}
