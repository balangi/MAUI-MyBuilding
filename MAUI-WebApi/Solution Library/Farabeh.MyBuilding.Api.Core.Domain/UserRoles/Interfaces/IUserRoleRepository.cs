namespace Farabeh.MyBuilding.Api.Core.Domain.UserRoles.Interfaces;

public interface IUserRoleRepository 
{ 
    List<UserRoleDto> GetAll(); 
    UserRoleDto GetItem(int id); 
    int Count(); 
}
