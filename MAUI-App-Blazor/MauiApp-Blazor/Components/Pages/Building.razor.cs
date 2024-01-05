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

    private void IncrementCount()
    {
        currentCount++;
    }
}
