#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.UserRoles;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly SqlDbContext _dbContext;

    public UserRoleRepository(SqlDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public int Count()
    {
        return _dbContext.UserRoles.Count();
    }

    public List<UserRoleDto> GetAll()
    {
        return _dbContext.UserRoles.ToList();
    }

    public UserRoleDto GetItem(int id)
    {
        return new UserRoleDto();
    }
}


