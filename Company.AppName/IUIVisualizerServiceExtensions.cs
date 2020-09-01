using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AppName
{
    public static class IUIVisualizerServiceExtensions
    {
        // TODO : PR
        // Lieber von UIVisualizerService erben und als Service setzen
        // Es müssen wohl dennoch die Extension angepasst werden oder eigenes Interface/Service ...
        // Kp warum das löschen jetzt nicht mehr im BaseRepo geht ...
        // Muss am Modul UC wirklich Conten.IsEnabled = true




        private static readonly Dictionary<string, Type> RegisteredWindows = new Dictionary<string, Type>();

        public static bool? Show<TViewModel>(this IUIVisualizerService uiVisualizerService, object model = null) where TViewModel : IViewModel
        {
            Argument.IsNotNull("uiVisualizerService", uiVisualizerService);

            var viewModelFactory = GetViewModelFactory(uiVisualizerService);
            var vm = viewModelFactory.CreateViewModel(typeof(TViewModel), model);
            return uiVisualizerService.ShowDialog<TViewModel>(vm);
        }

        public static bool? ShowDialog<TViewModel>(this IUIVisualizerService uiVisualizerService, object model = null) where TViewModel : IViewModel
        {
            Argument.IsNotNull("uiVisualizerService", uiVisualizerService);

            var viewModelFactory = GetViewModelFactory(uiVisualizerService);
            var vm = viewModelFactory.CreateViewModel(typeof(TViewModel), model);
            return uiVisualizerService.ShowDialog<TViewModel>(vm);
        }

        private static bool? ShowWindow(IViewModel dataContext, bool isModal)
        {
            Type windowType;

            lock(RegisteredWindows)
            {
                if(!RegisteredWindows.TryGetValue(dataContext.GetType().FullName, out windowType))
                    return null;
            }

            FrameworkElement frameworkElement = ViewHelper.ConstructViewWithViewModel(windowType, dataContext);
            Catel.Windows.Window window = frameworkElement as Catel.Windows.Window;

            if(window == null)
                throw new Exception("Could not create Window");

            if(isModal)
                return window.ShowDialog();


            window.Show();
            return null;
        }

        private static IViewModelFactory GetViewModelFactory(IUIVisualizerService uiVisualizerService)
        {
            var dependencyResolver = uiVisualizerService.GetDependencyResolver();
            var viewModelFactory = dependencyResolver.Resolve<IViewModelFactory>();
            return viewModelFactory;
        }
    }
}
