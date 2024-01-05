#nullable disable

namespace Farabeh.MyBuilding.Core.Domain.Buildings.Commands;

public class CreateBuildingCommand
{
    public string Name { get; set; }
    public string Manager { get; set; }
    public string Mobile { get; set; }
}
