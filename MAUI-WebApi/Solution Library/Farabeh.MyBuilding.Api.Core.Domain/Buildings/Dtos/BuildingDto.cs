#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos;

public class BuildingDto
{
    [Key]
    public long Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
}
