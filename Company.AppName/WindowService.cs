using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Catel;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using Catel.Reflection;
using Catel.Services;
using Catel.Windows.Threading;
using Company.Base.Presentation;

namespace Company.AppName
{
    public class WindowService : UIVisualizerService, IWindowService
    {
        private readonly IDispatcherService _dispatcherService;
        private readonly IViewModelFactory _viewModelFactory;
        private static readonly ILog _log = LogManager.GetCurrentClassLogger();


        public WindowService(IViewLocator viewLocator, IDispatcherService dispatcherService) : base(viewLocator, dispatcherService)
        {
            _dispatcherService = dispatcherService;
            _viewModelFactory = this.GetDependencyResolver().Resolve<IViewModelFactory>();
        }

        public bool? Show(IViewModel viewModel)
        {
            Argument.IsNotNull("viewModel", viewModel);

            var viewModelType = viewModel.GetType();
            var viewModelTypeName = viewModelType.FullName;

            RegisterViewForViewModelIfRequired(viewModelType);

            return Show(viewModelTypeName, viewModel);
        }

        private bool? Show(string name, object data)
        {
            Argument.IsNotNullOrWhitespace("name", name);

            EnsureViewIsRegistered(name);

            var window = CreateWindow(name, data, false);
            if(window != null)
            {
                return ShowWindow(window, data, false);
            }

            return false;
        }

        public bool? ShowDialog(IViewModel viewModel)
        {
            Argument.IsNotNull("viewModel", viewModel);

            var viewModelType = viewModel.GetType();
            var viewModelTypeName = viewModelType.FullName;

            RegisterViewForViewModelIfRequired(viewModelType);

            return ShowDialog(viewModelTypeName, viewModel);
        }

        private bool? ShowDialog(string name, object data)
        {
            Argument.IsNotNullOrWhitespace("name", name);

            EnsureViewIsRegistered(name);

            var window = CreateWindow(name, data, true);
            if(window != null)
            {
                return ShowWindow(window, data, true);
            }

            return false;
        }

        protected virtual FrameworkElement CreateWindow(string name, object data, bool isModal)
        {
            Type windowType;

            lock(RegisteredWindows)
            {
                if(!RegisteredWindows.TryGetValue(name, out windowType))
                {
                    return null;
                }
            }

            return CreateWindow(windowType, data, isModal);
        }

        protected virtual FrameworkElement CreateWindow(Type windowType, object data, bool isModal)
        {
            FrameworkElement window = null;

            _dispatcherService.BeginInvoke(() =>
            {
                try
                {

                    window = ViewHelper.ConstructViewWithViewModel(windowType, data);

                    if(isModal)
                    {
                        FrameworkElement activeWindow = GetActiveWindow();
                        if(!ReferenceEquals(window, activeWindow))
                        {
                            PropertyHelper.TrySetPropertyValue(window, "Owner", activeWindow);
                        }
                    }
                }
                catch(Exception ex)
                {
                    if(LogManager.IsDebugEnabled.Value)
                        Trace.WriteLine("Exception on creating window");
                    _log.Error(ex);
                }
            });

            return window;
        }

        protected virtual bool? ShowWindow(FrameworkElement window, object data, bool showModal)
        {
            System.Reflection.MethodInfo showMethodInfo = showModal ? window.GetType().GetMethodEx("ShowDialog") : window.GetType().GetMethodEx("Show");
            if(showModal && showMethodInfo is null)
            {
                _log.Warning("Method 'ShowDialog' not found on '{0}', falling back to 'Show'", window.GetType().Name);

                showMethodInfo = window.GetType().GetMethodEx("Show");
            }

            if(showMethodInfo is null)
            {
                _log.ErrorAndCreateException<NotSupportedException>($"Methods 'Show' or 'ShowDialog' not found on '{window.GetType().Name}', cannot show the window");
            }
            else
            {
                window.Dispatcher.Invoke(() =>
                {
                    // Safety net to prevent crashes when this is the main window
                    try
                    {
                        showMethodInfo.Invoke(window, null);
                    }
                    catch(Exception ex)
                    {
                        _log.Error(ex, $"An error occurred while showing window '{window.GetType().GetSafeFullName(true)}'");
                    }
                }, System.Windows.Threading.DispatcherPriority.Input, false);
            }

            PropertyHelper.TryGetPropertyValue(window, "DialogResult", out bool? dialogResult);

            if(dialogResult is null)
            {
                // See https://github.com/Catel/Catel/issues/1503, even though there is no real DialogResult,
                // we will get the result from the VM instead
                IViewModel vm = data as IViewModel;
                if(vm != null)
                {
                    dialogResult = vm.GetResult();
                }
            }

            return dialogResult;
        }

        public bool? ShowDialog<TViewModel>(object model) where TViewModel : IViewModel
        {
            var vm = _viewModelFactory.CreateViewModel(typeof(TViewModel), model);
            return ShowDialog(vm);
        }

        public bool? Show<TViewModel>(object model) where TViewModel : IViewModel
        {
            var vm = _viewModelFactory.CreateViewModel(typeof(TViewModel), model);
            return Show(vm);
        }
    }
}
