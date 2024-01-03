namespace Farabeh.MyBuilding.Framework.Bases;

public abstract class BaseDto
{
    public string CreatedByUser { get; set; }
    public string ModifiedByUser { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}
