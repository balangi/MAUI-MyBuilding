using Farabeh.MyBuilding.Core.Domain.Buildings.Dtos;
using MauiApp_Blazor.Database;

namespace MauiApp_Blazor.Components.Pages;

public partial class Building
{
    private List<BuildingDto> Buildings;
    private int currentCount = 0;

    protected async override Task OnInitializedAsync()
    {
        var db = new SqliteDbContext();
        Buildings = await db.GetAll();
    }

    private string LinkBuilder(string _route, string _parameter)
    {
        return _route + _parameter;
    }

    private void IncrementCount()
    {
        currentCount++;
    }
}
