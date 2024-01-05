#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly SqlDbContext _dbContext;

    public RoleRepository(SqlDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public int Count() 
    {
        return _dbContext.Roles.Count();
    }

    public List<RoleDto> GetAll() 
    {
        return _dbContext.Roles.ToList();
    }

    public RoleDto GetItem(int id) 
    {
        return _dbContext
            .Roles
            .Where(w => w.Id == id.ToString())
            .FirstOrDefault();
    }
}


