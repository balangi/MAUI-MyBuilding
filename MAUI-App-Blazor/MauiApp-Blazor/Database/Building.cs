using SQLite;

namespace MauiApp_Blazor.Database;
public class Building
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}
