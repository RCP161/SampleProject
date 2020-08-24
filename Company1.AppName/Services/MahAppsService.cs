namespace Company1.AppName.Services
{
    using System.Windows;
    using Catel;
    using Catel.MVVM;
    using Catel.Services;
    using Company1.AppName.Views;
    using global::MahApps.Metro.Controls;
    using global::MahApps.Metro.IconPacks;
    using Orchestra;
    using Orchestra.Models;
    using Orchestra.Services;
    using Orchestra.ViewModels;
    using Orchestra.Views;

    public class MahAppsService : IMahAppsService
    {
        public WindowCommands GetRightWindowCommands()
        {
            WindowCommands windowCommands = new WindowCommands();

            System.Windows.Controls.Button settingsButton = WindowCommandHelper.CreateWindowCommandButton(new PackIconMaterial { Kind = PackIconMaterialKind.Settings }, "settings");
            //settingsButton.SetCurrentValue(System.Windows.Controls.Primitives.ButtonBase.CommandProperty, _commandManager.GetCommand(AppCommands.Settings.General));
            windowCommands.Items.Add(settingsButton);

            return windowCommands;
        }

        public FlyoutsControl GetFlyouts()
        {
            return null;
        }

        public FrameworkElement GetMainView()
        {
            return new MainView();
        }

        public FrameworkElement GetStatusBar()
        {
            return null;
        }

        public AboutInfo GetAboutInfo()
        {
            return new AboutInfo();
        }
    }
}