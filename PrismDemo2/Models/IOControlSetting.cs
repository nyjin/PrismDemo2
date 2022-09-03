using System.Xml.Serialization;
using Prism.Mvvm;

namespace PrismDemo2.Models;

public class IOControlSetting : BindableBase
{
    private int _interval;

    [XmlAttribute]
    public int Interval
    {
        get => _interval;
        set => SetProperty(ref _interval, value);
    }
}