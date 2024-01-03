using SQLite;

namespace MauiApp_Blazor.Database;

public class SqliteDbContext
{
    private const string DbName = "sqlitedatabase.db3";
    private readonly SQLiteAsyncConnection _connection;

    public SqliteDbContext()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<Building>();
    }

    public async Task<List<Building>> GetAll()
    {
        return await _connection.Table<Building>().ToListAsync();
    }

    public async Task<Building> GetById(int buildingId)
    {
        return await _connection.Table<Building>().Where(w => w.Id == buildingId).FirstOrDefaultAsync();
    }

    public async Task Create(Building building)
    {
        await _connection.InsertAsync(building);
    }

    public async Task Update(Building building)
    {
        await _connection.UpdateAsync(building);
    }
}
