#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.UserRoles.Dtos;

public class UserRoleDto : IdentityUserRole<string>
{ 
    public virtual UserDto User { get; set; }
    public virtual RoleDto Role { get; set; }
}
