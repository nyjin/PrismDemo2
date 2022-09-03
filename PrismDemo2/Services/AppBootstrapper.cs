using System;
using System.Threading.Tasks;
using Prism.Mvvm;

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

public class SettingRepository : BindableBase
{
    private AppSetting _setting;
    public AppSetting Setting
    {
        get => _setting;
        set => SetProperty(ref _setting, value);
    }

    public SettingRepository()
    {

    }
}

public interface ISettingRepository
{
    AppSetting Setting { get; }
}

public class AppSetting : BindableBase
{
}


public class CameraSetting : BindableBase
{
    private AppSetting _setting;
    public AppSetting Setting
    {
        get => _setting;
        set => SetProperty(ref _setting, value);
    }
}