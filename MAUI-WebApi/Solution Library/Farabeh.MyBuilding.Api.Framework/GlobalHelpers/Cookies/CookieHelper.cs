#nullable disable

namespace Farabeh.MyBuilding.Api.Framework.GlobalHelpers.Cookies;

public class CookieHelper
{
    private readonly IHttpContextAccessor _context;

    public CookieHelper(IHttpContextAccessor context)
    {
        _context = context;
    }

    public void WriteCookie(string key, string value)
    {
        //Set the Expiry date of the Cookie.
        CookieOptions option = new CookieOptions();
        option.Expires = DateTime.Now.AddMinutes(1);

        //Create a Cookie with a suitable Key and add the Cookie to Browser.
        _context.HttpContext.Response.Cookies.Append(key, value, option);
    }

    public string ReadCookie(string key)
    {
        //Fetch the Cookie value using its Key.
        string value = _context.HttpContext.Request.Cookies[key];

        return !string.IsNullOrWhiteSpace(value) ? value : "undefined";
    }

    public void DeleteCookie(string key)
    {
        //Delete the Cookie from Browser.
        _context.HttpContext.Response.Cookies.Delete(key);
    }
}
