using System.Windows;

namespace PrismDemo2.Services;

public interface IWindowService
{
    void Transit<TTo>() where TTo : Window;
}