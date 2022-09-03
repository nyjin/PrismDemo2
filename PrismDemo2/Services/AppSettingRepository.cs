using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Prism.Mvvm;
using PrismDemo2.Models;

namespace PrismDemo2.Services;

public class AppSettingRepository : BindableBase, IAppSettingRepository
{
    private AppSetting _setting;

    private string SettingPath => Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "AppSetting.xml");
    public AppSetting Setting
    {
        get => _setting;
        set => SetProperty(ref _setting, value);
    }

    public AppSettingRepository()
    {
        Setting = File.Exists(SettingPath) ? PopulateSetting(SettingPath) : InitializeSetting();
    }

    private AppSetting PopulateSetting(string path)
    {
        var ser = new XmlSerializer(typeof(AppSetting));
        using var reader = XmlReader.Create(path);
        return (AppSetting)ser.Deserialize(reader)!;
    }

    private AppSetting InitializeSetting()
    {
        return new AppSetting
        {
            Camera = new CameraSetting
            {
                Height = 600,
                Width = 800,
                Version = "0.9"
            },
            IOControl = new IOControlSetting
            {
                Interval = 500
            }
        };
    }
}