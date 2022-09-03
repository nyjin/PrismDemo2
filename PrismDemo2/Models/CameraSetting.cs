using System.Xml.Serialization;
using Prism.Mvvm;

namespace PrismDemo2.Models;

public class CameraSetting : BindableBase
{
    private string _version;
    private int _height;
    private int _width;

    [XmlAttribute]
    public string Version
    {
        get => _version;
        set => SetProperty(ref _version, value);
    }

    [XmlAttribute]
    public int Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    [XmlAttribute]
    public int Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }
}