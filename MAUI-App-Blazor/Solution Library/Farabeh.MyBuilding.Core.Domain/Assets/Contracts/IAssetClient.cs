using Farabeh.MyBuilding.Core.Domain.Assets.Dtos;
using Farabeh.MyBuilding.Framework.Results;

namespace Farabeh.MyBuilding.Core.Domain.Assets.Contracts;

public interface IAssetClient
{
    Task<Result<AssetDto>> GetAssetById(string businessId);
}
