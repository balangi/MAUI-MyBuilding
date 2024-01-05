#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Users.Dtos;

public class UserDto : IdentityUser
{ 
    public ICollection<UserRoleDto> UserRoles { get; set; }

    //[InverseProperty(nameof(SponsorDto.UserInfo))]
    //public ICollection<SponsorDto> Sponsors { get; set; }

    public string FullName { get; set; }
    public bool Enable { get; set; }
}
