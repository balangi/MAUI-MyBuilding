using Farabeh.MyBuilding.Core.Domain.Buildings.Commands;
using Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;
using Farabeh.MyBuilding.Core.Domain.Buildings.Dtos;
using Farabeh.MyBuilding.Framework;
using MauiApp_Blazor.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MauiApp_Blazor.Components.Pages;

public partial class BuildingAdd
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

    private async void BuildingAdd_OnClick()
    {
        currentCount = _InputMsgModel.Name;

        var command = new CreateBuildingCommand
        {
            Name = _InputMsgModel.Name,
            Manager = _InputMsgModel.Manager,
            Mobile = _InputMsgModel.Mobile,
        };

        var result2 = await Client.CreateBuilding(command);
        if (result2.IsSuccess)
        {
            var db = new SqliteDbContext();
            
            var p = new BuildingDto
            {
                Name = _InputMsgModel.Name,
                Code = result2.Value.Message
            };

            await db.Create(p);

            //foreach (var building in Buildings)
            //{
            //    await db.Delete(building);
            //}

            NavigationManager.NavigateTo("/Building");
        }
        else
        {
            await JSRuntime.AlertError(result2.Error);
        }
    }
}

public class InputMsgModel
{
    public string Name { get; set; } = "Name";
    public string Manager { get; set; } = "Manager";
    public string Mobile { get; set; } = "Mobile";
}

