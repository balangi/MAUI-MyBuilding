#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Settings.Interfaces;

public interface ISettingsRepository
{
    SettingsDto GetItem(int id);

    SettingsDto GetItem(string key);

    List<SettingsDto> GetAll();

    WebsiteSettingsDto GetWebsiteSettings();

    bool Save(WebsiteSettingsDto data);
}
