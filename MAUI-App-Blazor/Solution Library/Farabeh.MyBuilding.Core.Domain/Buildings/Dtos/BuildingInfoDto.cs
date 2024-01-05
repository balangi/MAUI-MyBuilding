#nullable disable

namespace Farabeh.MyBuilding.Core.Domain.Buildings.Dtos;

public class BuildingInfoDto
{
    public List<BuildingDto> Buildings { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
