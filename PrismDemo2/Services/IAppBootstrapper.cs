using System;
using System.Threading.Tasks;

namespace PrismDemo2.Services;

public interface IAppBootstrapper
{
    Task InitializeAsync();
    event EventHandler<MessageEventArgs> LoadedControl;
    event EventHandler Completed;
}