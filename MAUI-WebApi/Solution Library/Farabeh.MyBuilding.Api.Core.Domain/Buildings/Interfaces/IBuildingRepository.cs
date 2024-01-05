namespace Farabeh.MyBuilding.Api.Core.Domain.Buildings.Interfaces;

public interface IBuildingRepository
{
    List<BuildingDto> GetAll();
    BuildingDto GetItem(int id);
    Task<List<BuildingDto>> GetBuildingsByCode(string code);
    bool FindByCode(string code);
    int Count();
    Task<long> Create(BuildingDto data);
    bool Update(BuildingDto data);
}
