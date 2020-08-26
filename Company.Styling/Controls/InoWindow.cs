using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Catel;
using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using Catel.MVVM.Providers;
using Catel.MVVM.Views;
using Catel.Services;
using Catel.Threading;
using MahApps.Metro.Controls;

namespace Company.Styling.Controls
{
    public class InoWindow : MetroWindow, IView
    {
        #region Fields

        private static readonly ILog _log = LogManager.GetCurrentClassLogger();
        private static readonly IWrapControlService _wrapControlService = ServiceLocator.Default.ResolveType<IWrapControlService>();

        private bool _isWrapped;

        private readonly WindowLogic _logic;

        private event EventHandler<EventArgs> ViewLoaded;
        private event EventHandler<EventArgs> ViewUnloaded;
        private event EventHandler<DataContextChangedEventArgs> ViewDataContextChanged;

        #endregion

        #region Constructor

        public InoWindow() : this(null)
        { }

        public InoWindow(IViewModel viewModel)
        {
            if(CatelEnvironment.IsInDesignMode)
                return;

            // Set window style (WPF doesn't allow styling on root elements of XAML files, too bad)
            // For more info, see http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/3059c0e4-c372-4da2-b384-28f271feef05/
            //SetResourceReference(StyleProperty, typeof(InoWindow));

            ThemeHelper.EnsureCatelMvvmThemeIsLoaded();

            _logic = new WindowLogic(this, null, viewModel);
            _logic.TargetViewPropertyChanged += (sender, e) =>
            {
                // Do not call this for ActualWidth and ActualHeight WPF, will cause problems with NET 40 
                // on systems where NET45 is *not* installed
                if(!String.Equals(e.PropertyName, nameof(ActualWidth), StringComparison.InvariantCulture) &&
                    !String.Equals(e.PropertyName, nameof(ActualHeight), StringComparison.InvariantCulture))
                {
                    PropertyChanged?.Invoke(this, e);
                }
            };

            _logic.ViewModelClosedAsync += OnViewModelClosedAsync;
            _logic.ViewModelChanged += (sender, e) => RaiseViewModelChanged();

            _logic.ViewModelPropertyChanged += (sender, e) =>
            {
                OnViewModelPropertyChanged(sender, e);

                ViewModelPropertyChanged?.Invoke(this, e);
            };

            Loaded += (sender, e) =>
            {
                ViewLoaded?.Invoke(this, EventArgs.Empty);

                OnLoaded(e);
            };

            Unloaded += (sender, e) =>
            {
                ViewUnloaded?.Invoke(this, EventArgs.Empty);

                OnUnloaded(e);
            };


            DataContextChanged += (sender, e) => ViewDataContextChanged?.Invoke(this, new DataContextChangedEventArgs(e.OldValue, e.NewValue));
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of the view model that this user control uses.
        /// </summary>
        public Type ViewModelType
        {
            get { return _logic.GetValue<WindowLogic, Type>(x => x.ViewModelType); }
        }

        /// <summary>
        /// Gets or sets a the view model lifetime management.
        /// <para />
        /// By default, this value is <see cref="ViewModelLifetimeManagement"/>.
        /// </summary>
        /// <value>
        /// The view model lifetime management.
        /// </value>
        public ViewModelLifetimeManagement ViewModelLifetimeManagement
        {
            get { return _logic.GetValue<WindowLogic, ViewModelLifetimeManagement>(x => x.ViewModelLifetimeManagement); }
            set { _logic.SetValue<WindowLogic>(x => x.ViewModelLifetimeManagement = value); }
        }

        /// <summary>
        /// Gets the view model that is contained by the container.
        /// </summary>
        /// <value>The view model.</value>
        public IViewModel ViewModel
        {
            get { return _logic.GetValue<WindowLogic, IViewModel>(x => x.ViewModel); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a property on the container has changed.
        /// </summary>
        /// <remarks>
        /// This event makes it possible to externally subscribe to property changes of a <see cref="DependencyObject"/>
        /// (mostly the container of a view model) because the .NET Framework does not allows us to.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the <see cref="ViewModel"/> property has changed.
        /// </summary>
        public event EventHandler<EventArgs> ViewModelChanged;

        /// <summary>
        /// Occurs when a property on the <see cref="ViewModel"/> has changed.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> ViewModelPropertyChanged;

        /// <summary>
        /// Occurs when the view is loaded.
        /// </summary>
        event EventHandler<EventArgs> IView.Loaded
        {
            add { ViewLoaded += value; }
            remove { ViewLoaded -= value; }
        }

        /// <summary>
        /// Occurs when the view is unloaded.
        /// </summary>
        event EventHandler<EventArgs> IView.Unloaded
        {
            add { ViewUnloaded += value; }
            remove { ViewUnloaded -= value; }
        }

        /// <summary>
        /// Occurs when the data context has changed.
        /// </summary>
        event EventHandler<DataContextChangedEventArgs> IView.DataContextChanged
        {
            add { ViewDataContextChanged += value; }
            remove { ViewDataContextChanged -= value; }
        }

        #endregion

        #region Methods

        private void RaiseViewModelChanged()
        {
            OnViewModelChanged();

            ViewModelChanged?.Invoke(this, EventArgs.Empty);
            RaisePropertyChanged(nameof(ViewModel));

            if(_logic.HasVmProperty)
                RaisePropertyChanged("VM");
        }

        /// <summary>
        /// Raises the <c>PropertyChanged</c> event.
        /// </summary>
        /// <param name="propertyName">The property name to raise the event for.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the control has been initialized.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if(CatelEnvironment.IsInDesignMode)
                return;

            FrameworkElement newContentAsFrameworkElement = Content as FrameworkElement;
            if(_isWrapped || !_wrapControlService.CanBeWrapped(newContentAsFrameworkElement))
                return;

            _isWrapped = true;
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <returns>True if successful, otherwise false.</returns>
        protected virtual bool ValidateData()
        {
            _logic.ValidateViewModel();

            IViewModel vm = _logic.ViewModel;
            if(vm is null)
                return true;

            Catel.Data.IValidationContext validationContext = vm.ValidationContext;
            return !validationContext.HasErrors;
        }


        /// <summary>
        /// Called when a property on the current view model has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnViewModelPropertyChanged(e);
        }

        /// <summary>
        /// Called when a property on the current <see cref="ViewModel"/> has changed.
        /// </summary>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnViewModelPropertyChanged(PropertyChangedEventArgs e)
        { }

        /// <summary>
        /// Called when the <see cref="ViewModel"/> has been closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        protected virtual Task OnViewModelClosedAsync(object sender, ViewModelClosedEventArgs e)
        {
            return TaskHelper.Completed;
        }

        /// <summary>
        /// Called when the <see cref="ViewModel"/> has changed.
        /// </summary>
        /// <remarks>
        /// This method does not implement any logic and saves a developer from subscribing/unsubscribing
        /// to the <see cref="ViewModelChanged"/> event inside the same user control.
        /// </remarks>
        protected virtual void OnViewModelChanged()
        { }

        /// <summary>
        /// Called when the <see cref="DataWindow"/> is loaded.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnLoaded(EventArgs e)
        { }

        /// <summary>
        /// Called when the <see cref="DataWindow"/> is unloaded.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUnloaded(EventArgs e)
        { }

        /// <summary>
        /// Called when a dependency property on this control has changed.
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        { }

        #endregion
    }
}
