using System;
using System.Threading.Tasks;

namespace PrismDemo2.Services;

public class AppBootstrapper : IAppBootstrapper
{
    private readonly Lazy<CameraControl> _lazyControl;
    private readonly Lazy<IOControl> _lazyIoControl;

    public event EventHandler<MessageEventArgs> LoadedControl;
    public event EventHandler Completed;

    public AppBootstrapper(Lazy<CameraControl> lazyControl, Lazy<IOControl> lazyIoControl)
    {
        _lazyControl = lazyControl;
        _lazyIoControl = lazyIoControl;
    }

    public Task InitializeAsync()
    {
        return Task.Run(() =>
        {
            _ = _lazyControl.Value;
            OnLoadedControl(new MessageEventArgs("CameraControl Loaded"));
            _ = _lazyIoControl.Value;
            OnLoadedControl(new MessageEventArgs("IOControl Loaded"));
            OnCompleted();
        });
    }

    protected virtual void OnLoadedControl(MessageEventArgs e)
    {
        LoadedControl?.Invoke(this, e);
    }

    protected virtual void OnCompleted()
    {
        Completed?.Invoke(this, EventArgs.Empty);
    }
}