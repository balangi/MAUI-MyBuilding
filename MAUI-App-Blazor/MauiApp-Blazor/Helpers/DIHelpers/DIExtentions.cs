using Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;
using Farabeh.MyBuilding.Framework.Serializers;
using Farabeh.MyBuilding.Infra.Data.Api.Buildings;
using Microsoft.Extensions.Configuration;

namespace MauiApp_Blazor.Helpers.DIHelpers;

public static class DIExtentions
{
    internal const string baseAddress = "https://192.168.1.6:44343";

    public static void AddAllServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClients(configuration);
        services.AddTransient<ISerializer, NewtonsoftJsonSerializer>();
    }

    public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IBuildingClient, BuildingClient>(option => option.BaseAddress = new System.Uri(baseAddress));
    }
}
