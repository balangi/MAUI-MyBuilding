#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Users;

public class UserRepository : IUserRepository
{
    private readonly SqlDbContext _dbContext;

    public UserRepository(SqlDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public int AllCount()
    {
        return _dbContext.Users.Count();
    }

    public int EnableCount()
    {
        return _dbContext
            .Users
            .Where(w => w.Enable == true)
            .Count();
    }

    public List<UserDto> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public UserDto GetItem(int id)
    {
        return _dbContext
            .Users
            .Where(w => w.Id == id.ToString())
            .FirstOrDefault();
    }
}


