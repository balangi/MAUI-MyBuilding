namespace Farabeh.MyBuilding.Api.Core.Domain.UserClaims.Interfaces;

public interface IUserClaimRepository 
{ 
    List<UserClaimDto> GetAll(); 
    UserClaimDto GetItem(int id); 
    int Count(); 
}
