using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismDemo2.ViewModels;

public class SettingViewModel : BindableBase, IDialogAware
{
    private string _title;
    private string _message;
    private DelegateCommand<string> _closeDialogCommand;

    public event Action<IDialogResult> RequestClose;

    public ICommand LoadedCommand { get; }

    public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ??= new DelegateCommand<string>(OnClose);

    
    public string Message
    {
        get { return _message; }
        set { SetProperty(ref _message, value); }
    }

    private void OnClose(string parameter)
    {
        ButtonResult result = ButtonResult.None;

        if (parameter?.ToLower() == "true")
            result = ButtonResult.OK;
        else if (parameter?.ToLower() == "false")
            result = ButtonResult.Cancel;

        RequestClose(new DialogResult(result));
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public SettingViewModel()
    {
        LoadedCommand = new DelegateCommand(OnLoaded);
    }

    private void OnLoaded()
    {
        Title = "Hello";
    }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
        
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Message = parameters.GetValue<string>("message");
    }
}