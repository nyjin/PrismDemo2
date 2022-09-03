using System.Threading;
using System.Windows;
using Prism.Ioc;

namespace PrismDemo2.Services;

public class WindowService : IWindowService
{
    private readonly SynchronizationContext _synchronizationContext;
    private readonly IContainerProvider _containerProvider;

    public WindowService(SynchronizationContext synchronizationContext, IContainerProvider containerProvider)
    {
        _synchronizationContext = synchronizationContext;
        _containerProvider = containerProvider;
    }

    public void Transit<TTo>() where TTo : Window
    {
        _synchronizationContext.Post((_) =>
        {
            var toWindow = _containerProvider.Resolve<TTo>();
            App.Current.MainWindow.Close();
            toWindow.Show();
        }, null);
        
    }
}