#nullable disable

using Microsoft.AspNetCore.Http;

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Settings;

public class SettingsRepository : ISettingsRepository
{
    private readonly SqlDbContext _dbContext;
    private readonly UserManager<UserDto> _userManager;
    private readonly IHttpContextAccessor _httpContext;

    public SettingsRepository(
        SqlDbContext dbContext,
        UserManager<UserDto> userManager,
        IHttpContextAccessor httpContext
    )
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _httpContext = httpContext;
    }

    public List<SettingsDto> GetAll()
    {
        return _dbContext.Settings.ToList();
    }

    public SettingsDto GetItem(int id)
    {
        return _dbContext
            .Settings
            .Where(w => w.Id == id)
            .FirstOrDefault();
    }

    public SettingsDto GetItem(string key)
    {
        return _dbContext
            .Settings
            .Where(w => w.Key == key)
            .FirstOrDefault();
    }

    public WebsiteSettingsDto GetWebsiteSettings()
    {
        var settings = _dbContext.Settings;
        var MainSliderListCount = settings != null && settings.Count() > 0 && settings.Where(w => w.Key == "MainSliderListCount").FirstOrDefault() != null ? Convert.ToInt32(settings.Where(w => w.Key == "MainSliderListCount").First().Value) : 0;
        var NewsListCount = settings != null && settings.Count() > 0 && settings.Where(w => w.Key == "NewsListCount").FirstOrDefault() != null ? Convert.ToInt32(settings.Where(w => w.Key == "NewsListCount").First().Value) : 0;
        var NotificationListCount = settings != null && settings.Count() > 0 && settings.Where(w => w.Key == "NotificationListCount").FirstOrDefault() != null ? Convert.ToInt32(settings.Where(w => w.Key == "NotificationListCount").First().Value) : 0;
        var LinkListCount = settings != null && settings.Count() > 0 && settings.Where(w => w.Key == "LinkListCount").FirstOrDefault() != null ? Convert.ToInt32(settings.Where(w => w.Key == "LinkListCount").First().Value) : 0;
        var BossSliderListCount = settings != null && settings.Count() > 0 && settings.Where(w => w.Key == "BossSliderListCount").FirstOrDefault() != null ? Convert.ToInt32(settings.Where(w => w.Key == "BossSliderListCount").First().Value) : 0;

        var websiteSettings = new WebsiteSettingsDto
        {
            MainSliderListCount = MainSliderListCount,
            NewsListCount = NewsListCount,
            NotificationListCount = NotificationListCount,
            LinkListCount = LinkListCount,
            BossSliderListCount = BossSliderListCount,
        };

        return websiteSettings;
    }

    public bool Save(WebsiteSettingsDto data)
    {
        try
        {
            var settings = _dbContext.Settings;
            var result = false;

            // MainSliderListCount
            if (
                settings != null &&
                settings.Count() > 0 &&
                settings.Where(w => w.Key == "MainSliderListCount").FirstOrDefault() != null
               )
            {
                result = Edit(new SettingsDto { Key = "MainSliderListCount", Value = data.MainSliderListCount.ToString(), });
            }
            else
            {
                result = Add(new SettingsDto { Key = "MainSliderListCount", Value = data.MainSliderListCount.ToString(), });
            }
            result = result && true;


            // BossSliderListCount
            if (
                settings != null &&
                settings.Count() > 0 &&
                settings.Where(w => w.Key == "BossSliderListCount").FirstOrDefault() != null
               )
            {
                result = Edit(new SettingsDto { Key = "BossSliderListCount", Value = data.BossSliderListCount.ToString(), });
            }
            else
            {
                result = Add(new SettingsDto { Key = "BossSliderListCount", Value = data.BossSliderListCount.ToString(), });
            }
            result = result && true;


            // NewsListCount
            if (
                settings != null &&
                settings.Count() > 0 &&
                settings.Where(w => w.Key == "NewsListCount").FirstOrDefault() != null
               )
            {
                result = Edit(new SettingsDto { Key = "NewsListCount", Value = data.NewsListCount.ToString(), });
            }
            else
            {
                result = Add(new SettingsDto { Key = "NewsListCount", Value = data.NewsListCount.ToString(), });
            }
            result = result && true;


            // NotificationListCount
            if (
                settings != null &&
                settings.Count() > 0 &&
                settings.Where(w => w.Key == "NotificationListCount").FirstOrDefault() != null
               )
            {
                result = Edit(new SettingsDto { Key = "NotificationListCount", Value = data.NotificationListCount.ToString(), });
            }
            else
            {
                result = Add(new SettingsDto { Key = "NotificationListCount", Value = data.NotificationListCount.ToString(), });
            }
            result = result && true;

            if (
                settings != null &&
                settings.Count() > 0 &&
                settings.Where(w => w.Key == "LinkListCount").FirstOrDefault() != null
               )
            {
                result = Edit(new SettingsDto { Key = "LinkListCount", Value = data.LinkListCount.ToString(), });
            }
            else
            {
                result = Add(new SettingsDto { Key = "LinkListCount", Value = data.LinkListCount.ToString(), });
            }
            result = result && true;

            return result;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Add(SettingsDto data)
    {
        var user = _httpContext.HttpContext?.User;

        data.CreatedBy = _userManager.GetUserId(user);
        data.CreatedDate = DateTime.Now;

        _dbContext.Settings.Add(data);
        _dbContext.SaveChanges();
        return data.Id > 0;
    }

    public bool Edit(SettingsDto data)
    {
        try
        {
            var originData = _dbContext.Settings.Where(s => s.Key == data.Key).FirstOrDefault();

            originData.Value = data.Value;

            _dbContext.Settings.Update(originData);
            _dbContext.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

