using Farabeh.MyBuilding.Core.Domain.Assets.Contracts;
using Farabeh.MyBuilding.Core.Domain.Assets.Dtos;
using Farabeh.MyBuilding.Framework.HttpClinet;
using Farabeh.MyBuilding.Framework.Results;

namespace Farabeh.MyBuilding.Infra.Data.Api.Assets;

public class AssetClient : BaseHttpClient, IAssetClient //, IRefreshDataService<AssetDto>
{
    public AssetClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<Result<AssetDto>> GetAssetById(string businessId)
    {
        return await GetAsync<AssetDto>(AssetRoutes.GetAssetById + $"?name={businessId}");
    }

    //public async Task<Result<string>> CreateAsset(CreateAssetCommand command)
    //{
    //    return await PostAsync<CreateAssetCommand, string>
    //        (command, AssetRoutes.CreateAsset);
    //}
}
