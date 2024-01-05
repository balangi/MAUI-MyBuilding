#nullable disable

namespace Farabeh.MyBuilding.Api.Framework.Configurations;

public class AppSettings
{
    private bool _afterLoginRedirectToAdminPanel;
    private string _baseDomainName;

    public bool AfterLoginRedirectToAdminPanel
    {
        get
        {
            try
            {
                _afterLoginRedirectToAdminPanel = Convert.ToBoolean(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .GetSection("AppConfigs")["AfterLoginRedirectToAdminPanel"]);

                return _afterLoginRedirectToAdminPanel;
            }
            catch
            {
                return _afterLoginRedirectToAdminPanel;
            }
        }
    }

    public string BaseDomainName
    {
        get
        {
            try
            {
                _baseDomainName = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .GetSection("AppConfigs")["BaseDomainName"];

                return _baseDomainName;
            }
            catch
            {
                return "http://localhost";
            }
        }
    }
}

