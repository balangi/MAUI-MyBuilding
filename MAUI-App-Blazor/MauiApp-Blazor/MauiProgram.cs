using MauiApp_Blazor.Database;
using MauiApp_Blazor.Helpers.DIHelpers;
using Microsoft.Extensions.Logging;

namespace MauiApp_Blazor;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("dana-fanum-regular.ttf", "DanaRegular");
                fonts.AddFont("IRANSans-FaNum-Regular.ttf", "IRANSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddAllServices(builder.Configuration);

        builder.Services.AddSingleton<SqliteDbContext>();
        return builder.Build();
    }
}