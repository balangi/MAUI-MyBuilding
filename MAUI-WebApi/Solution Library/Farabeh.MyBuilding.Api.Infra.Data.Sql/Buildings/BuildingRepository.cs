#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Pages;

public class BuildingRepository : IBuildingRepository
{
    private readonly SqlDbContext _dbContext;
    private readonly UserManager<UserDto> _userManager;
    private readonly IHttpContextAccessor _httpContext;

    public BuildingRepository(
        SqlDbContext dbContext,
        UserManager<UserDto> userManager,
        IHttpContextAccessor httpContext
        )
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _httpContext = httpContext;
    }

    public int Count() 
    {
        return _dbContext.Buildings.Count();
    }

    public List<BuildingDto> GetAll() 
    {
        return _dbContext.Buildings.ToList();
    }

    public BuildingDto GetItem(int id) 
    {
        return _dbContext
            .Buildings
            .Where(w => w.Id == id)
            .FirstOrDefault();
    }

    public async Task<long> Create(BuildingDto data)
    {
        var user = _httpContext.HttpContext?.User;

        data.CreatedBy = _userManager.GetUserId(user);
        data.CreatedDate = DateTime.Now;

        _dbContext.Buildings.Add(data);
        await _dbContext.SaveChangesAsync();
        return data.Id;
    }

    public bool Update(BuildingDto data)
    {
        try
        {
            var originData = _dbContext.Buildings.Where(s => s.Id == data.Id).FirstOrDefault();

            originData.Name = data.Name;

            _dbContext.Buildings.Update(originData);
            _dbContext.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}


