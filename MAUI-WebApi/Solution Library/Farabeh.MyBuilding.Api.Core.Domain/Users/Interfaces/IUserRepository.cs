namespace Farabeh.MyBuilding.Api.Core.Domain.Users.Interfaces;

public interface IUserRepository 
{ 
    List<UserDto> GetAll(); 
    UserDto GetItem(int id); 
    int AllCount(); 
    int EnableCount(); 
}
