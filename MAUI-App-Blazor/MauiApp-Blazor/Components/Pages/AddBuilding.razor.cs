using Farabeh.MyBuilding.Core.Domain.Buildings.Commands;
using Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;
using Farabeh.MyBuilding.Framework;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MauiApp_Blazor.Components.Pages;

public partial class AddBuilding
{
    InputMsgModel _InputMsgModel = new InputMsgModel();

    [Inject]
    public IBuildingClient Client { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    private void SubmitText()
    {
    }

    private string currentCount = "";

    private async void IncrementCount()
    {
        currentCount = _InputMsgModel.Msg;

        //var db = new SqliteDbContext();
        //var p = new Building { Name = _InputMsgModel.Msg };
        //await db.Create(p);

        //List<Building> Products = await db.GetAll();

        var command = new CreateBuildingCommand
        {
            Name = _InputMsgModel.Msg
        };

        var result2 = await Client.CreateBuilding(command);
        if (result2.IsSuccess)
        {
            NavigationManager.NavigateTo("/manager");
        }
        else
        {
            await JSRuntime.AlertError(result2.Error);
        }
    }
}

public class InputMsgModel
{
    public string Msg { get; set; } = "My new message";
}

