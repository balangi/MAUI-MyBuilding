namespace Farabeh.MyBuilding.Api.Core.Domain.Buildings.Interfaces;

public interface IBuildingRepository
{
    List<BuildingDto> GetAll();
    BuildingDto GetItem(int id);
    int Count();
    Task<long> Create(BuildingDto data);
    bool Update(BuildingDto data);
}
