using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismDemo2.Models;
using PrismDemo2.Services;

namespace PrismDemo2.ViewModels;

public class SettingViewModel : BindableBase, IDialogAware
{
    private readonly IAppSettingRepository _settingRepository;
    private string _title;
    private DelegateCommand _closeDialogCommand;

    public event Action<IDialogResult> RequestClose;

    public DelegateCommand CloseCommand => _closeDialogCommand ??= new DelegateCommand(OnClose);
    public AppSetting Setting => _settingRepository.Setting;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public SettingViewModel(IAppSettingRepository settingRepository)
    {
        _settingRepository = settingRepository;
    }

    private void OnClose()
    {
        RequestClose(new DialogResult(ButtonResult.OK));
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
        Title = parameters.GetValue<string>("message");
    }
}