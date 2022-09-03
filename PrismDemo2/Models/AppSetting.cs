using System.Xml.Serialization;
using Prism.Mvvm;

namespace PrismDemo2.Models;

[XmlRoot]
public class AppSetting : BindableBase
{
    private CameraSetting _camera;
    private IOControlSetting _ioControl;

    [XmlElement]
    public CameraSetting Camera
    {
        get => _camera;
        set => SetProperty(ref _camera, value);
    }

    [XmlElement]
    public IOControlSetting IOControl
    {
        get => _ioControl;
        set => SetProperty(ref _ioControl, value);
    }
}