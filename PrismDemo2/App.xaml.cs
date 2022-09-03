using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using PrismDemo2.Services;
using PrismDemo2.ViewModels;
using PrismDemo2.Views;

namespace PrismDemo2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private readonly string[] _possibleViews = new[] { "Window", "Dialog", "View" };

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IOControl>();
            containerRegistry.RegisterSingleton<CameraControl>();
            containerRegistry.RegisterSingleton<IWindowService, WindowService>();
            containerRegistry.RegisterSingleton<IAppSettingRepository, AppSettingRepository>();
            containerRegistry.RegisterSingleton<IAppBootstrapper, AppBootstrapper>();
            containerRegistry.RegisterInstance(SynchronizationContext.Current);
            containerRegistry.RegisterDialog<SettingView, SettingViewModel>("NotificationDialog");
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewName = viewType.FullName?.Replace(".Views.", ".ViewModels.");
                var viewModelName = string.Empty;

                foreach (var endViewName in _possibleViews)
                {
                    if (viewName.EndsWith(endViewName))
                    {
                        viewModelName = viewName[..viewName.LastIndexOf(endViewName, StringComparison.Ordinal)];
                        break;
                    }
                }

                var viewModelFullName = $"{viewModelName}ViewModel, {viewAssemblyName}";
                return Type.GetType(viewModelFullName);
            });
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<SplashWindow>();
        }
    }
}
