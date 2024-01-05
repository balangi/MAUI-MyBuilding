#nullable disable

using Farabeh.MyBuilding.Core.Domain.Buildings.Commands;
using Farabeh.MyBuilding.Core.Domain.Buildings.Contracts;
using Farabeh.MyBuilding.Framework;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MauiApp_Blazor.Components.Pages;

public partial class Home
{
    private bool firstPage = true;
    // private List<Building> Products = null;

    [Inject]
    public IBuildingClient Client { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }


    protected async override Task OnInitializedAsync()
    {
        // var db = new SqliteDbContext();
        // Products = await db.GetAll();

        var result = await Client.GetBuildingById("123456");
        if (result.IsSuccess)
        {
        }
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // var menuHeight = "";
            var headerHeight = "";
            var footerHeight = "";

            var Width = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            var height = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

            if (firstPage)
            {
                // var dimHeader = await JSRuntime.InvokeAsync<string>("getDimensions", "header");
                // if (dimHeader != null)
                // {
                //     dynamic d = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dimHeader);
                //     headerHeight = d.height;
                // }

                // if (height != 0 && headerHeight != null)
                // {
                //     var contentHeight = (Convert.ToInt64(height) - (Convert.ToInt64(headerHeight) + 60)).ToString();
                //     await JSRuntime.InvokeAsync<string>("setDimensions", "first-page", contentHeight);
                // }
            }
            else
            {
                // var dimMenu = await JSRuntime.InvokeAsync<string>("getDimensions", "menu");
                // if (dimMenu != null)
                // {
                //     dynamic d = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dimMenu);
                //     menuHeight = d.height;
                // }

                var dimHeader = await JSRuntime.InvokeAsync<string>("getDimensions", "header");
                if (dimHeader != null)
                {
                    dynamic d = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dimHeader);
                    headerHeight = d.height;
                }

                var dimFooter = await JSRuntime.InvokeAsync<string>("getDimensions", "footer");
                if (dimFooter != null)
                {
                    dynamic d = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dimFooter);
                    footerHeight = d.height;
                }

                if (height != 0 && headerHeight != null && footerHeight != null)
                {
                    var contentHeight = (Convert.ToInt64(height) - (Convert.ToInt64(headerHeight) + Convert.ToInt64(footerHeight) + 120)).ToString();
                    await JSRuntime.InvokeAsync<string>("setDimensions", "content", contentHeight);
                }
            }
        }
    }
}
