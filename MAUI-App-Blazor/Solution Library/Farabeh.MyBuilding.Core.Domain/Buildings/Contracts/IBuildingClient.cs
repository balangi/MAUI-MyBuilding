using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos.Outputs;
using Farabeh.MyBuilding.Core.Domain.Buildings.Commands;
using Farabeh.MyBuilding.Framework.Results;

namespace Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;

public interface IBuildingClient
{
    Task<Result<BuildingInfoDto>> GetBuildingById(string businessId);
    Task<Result<BuildingInfoDto>> CreateBuilding(CreateBuildingCommand command);
}
