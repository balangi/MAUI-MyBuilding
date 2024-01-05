#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Settings.Dtos;

public class SettingsDto
{
    [Key]
    public long Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
