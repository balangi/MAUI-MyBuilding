namespace Farabeh.MyBuilding.Api.Core.Domain.Roles.Interfaces;

public interface IRoleRepository 
{ 
    List<RoleDto> GetAll(); 
    RoleDto GetItem(int id); 
    int Count(); 
}
