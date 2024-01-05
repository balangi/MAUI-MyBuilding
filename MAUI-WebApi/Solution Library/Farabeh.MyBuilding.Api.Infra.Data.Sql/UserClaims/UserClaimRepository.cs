#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.UserClaims;

public class UserClaimRepository : IUserClaimRepository
{
    private readonly SqlDbContext _dbContext;

    public UserClaimRepository(SqlDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public int Count() 
    {
        return _dbContext.UserClaims.Count();
    }

    public List<UserClaimDto> GetAll() 
    {
        return _dbContext.UserClaims.ToList();
    }

    public UserClaimDto GetItem(int id) 
    {
        return _dbContext
            .UserClaims
            .Where(w => w.Id == id)
            .FirstOrDefault();
    }
}


