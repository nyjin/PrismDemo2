using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismDemo2.Services;

namespace PrismDemo2.ViewModels;

public class MainViewModel : BindableBase
{
    private readonly CameraControl _cameraControl;
    private readonly IOControl _ioControl;
    private readonly IDialogService _dialogService;
    private string _title;

    public ICommand LoadedCommand { get; }
    public ICommand OpenSettingCommand { get; }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public MainViewModel(CameraControl cameraControl, IOControl ioControl, IDialogService dialogService)
    {
        _cameraControl = cameraControl;
        _ioControl = ioControl;
        _dialogService = dialogService;
        LoadedCommand = new DelegateCommand(OnLoaded);
        OpenSettingCommand = new DelegateCommand(OnOpenSetting);
    }

    private void OnOpenSetting()
    {
        _dialogService.ShowDialog("NotificationDialog", new DialogParameters("message=Hello"), r =>
        {
            if (r.Result == ButtonResult.None)
                Title = "Result is None";
            else if (r.Result == ButtonResult.OK)
                Title = "Result is OK";
            else if (r.Result == ButtonResult.Cancel)
                Title = "Result is Cancel";
            else
                Title = "I Don't know what you did!?";
        });
    }

    private void OnLoaded()
    {
        Title = "Hello";
    }
}