using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using PrismDemo2.Services;
using PrismDemo2.Views;

namespace PrismDemo2.ViewModels;

public class SplashViewModel : BindableBase
{
    private readonly IAppBootstrapper _bootstrapper;
    private readonly IWindowService _windowService;
    private string _message;
    public ICommand LoadedCommand { get; }

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    public SplashViewModel(IAppBootstrapper bootstrapper, IWindowService windowService)
    {
        _bootstrapper = bootstrapper;
        _windowService = windowService;
        LoadedCommand = new DelegateCommand(async () => await OnLoaded());
    }

    private Task OnLoaded()
    {
        _bootstrapper.LoadedControl += OnLoadedControl;
        _bootstrapper.Completed += OnCompleted;
        return _bootstrapper.InitializeAsync();
    }

    private void OnCompleted(object? sender, EventArgs e)
    {
        Thread.Sleep(300);
        _windowService.Transit<MainWindow>();
    }

    private void OnLoadedControl(object? sender, MessageEventArgs e)
    {
        Message = e.Message;
    }
}