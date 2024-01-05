#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Roles.Dtos;

public class RoleDto : IdentityRole<string>
{ 
    public string Description { get; set; }
    public ICollection<UserRoleDto> UserRoles { get; set; }
}
