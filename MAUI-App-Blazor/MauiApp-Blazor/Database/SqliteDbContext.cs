using Farabeh.MyBuilding.Core.Domain.Buildings.Dtos;
using SQLite;

namespace MauiApp_Blazor.Database;

public class SqliteDbContext
{
    private const string DbName = "sqlitedatabase.db3";
    private readonly SQLiteAsyncConnection _connection;

    public SqliteDbContext()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<BuildingDto>();
    }

    public async Task<List<BuildingDto>> GetAll()
    {
        return await _connection.Table<BuildingDto>().ToListAsync();
    }

    public async Task<BuildingDto> GetById(int buildingId)
    {
        return await _connection.Table<BuildingDto>().Where(w => w.Id == buildingId).FirstOrDefaultAsync();
    }

    public async Task Create(BuildingDto building)
    {
        await _connection.InsertAsync(building);
    }

    public async Task Update(BuildingDto building)
    {
        await _connection.UpdateAsync(building);
    }

    public async Task Delete(BuildingDto building)
    {
        await _connection.DeleteAsync(building);
    }
}
