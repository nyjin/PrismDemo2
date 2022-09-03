using PrismDemo2.Models;

namespace PrismDemo2.Services;

public interface IAppSettingRepository
{
    AppSetting Setting { get; }
}