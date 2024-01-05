using Farabeh.MyBuilding.Core.Domain.Buildings.Commands;
using Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;
using Farabeh.MyBuilding.Core.Domain.Buildings.Dtos;
using Farabeh.MyBuilding.Framework.HttpClinet;
using Farabeh.MyBuilding.Framework.Results;

namespace Farabeh.MyBuilding.Infra.Data.Api.Buildings;

public class BuildingClient : BaseHttpClient, IBuildingClient //, IRefreshDataService<BuildingDto>
{
    public BuildingClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<Result<BuildingInfoDto>> GetBuildingById(string businessId)
    {
        return await GetAsync<BuildingInfoDto>(BuildingRoutes.GetBuildingsByCode + $"?name={businessId}");
    }

    public async Task<Result<BuildingInfoDto>> CreateBuilding(CreateBuildingCommand command)
    {
        return await PostAsync<CreateBuildingCommand, BuildingInfoDto>
            (command, BuildingRoutes.CreateBuilding);
    }
}
