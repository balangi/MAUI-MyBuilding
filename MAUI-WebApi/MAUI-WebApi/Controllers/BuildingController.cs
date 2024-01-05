using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos;
using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos.Inputs;
using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos.Outputs;
using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAUI_WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;
    private readonly IBuildingRepository _building;

    public BuildingController(
        ILogger<BuildingController> logger,
        IBuildingRepository building
        )
    {
        _logger = logger;
        _building = building;
    }

    [HttpGet("~/api/Building/GetBuildingsByCode")]
    public async Task<BuildingInfoDto> GetBuildingsByCode([FromQuery] string code)
    {
        List<BuildingDto> buildings = null;
        var message = "";
        var isSuccess = false;
        try
        {
            buildings = await _building.GetBuildingsByCode(code);
            message = "";
            isSuccess = true;
        }
        catch (Exception ex)
        {
            message = ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message)
                ? ex.InnerException.Message
                : ex.Message;
        }

        return new BuildingInfoDto
        {
            Buildings = buildings,
            IsSuccess = isSuccess,
            Message = message
        };
    }

    [HttpPost("~/api/Building/Create")]
    public async Task<BuildingInfoDto> CreateBuilding([FromBody] BuildingInputDto buildingInput)
    {
        Random rand = new Random();
        var ranCode = rand.Next(1000000, 9999999).ToString("D6");

        var codeFounded =  _building.FindByCode(ranCode);
        
        if (codeFounded)
        {
            ranCode = rand.Next(1000000, 9999999).ToString("D6");
        }

        var building = new BuildingDto
        {
            Name = buildingInput.Name,
            Manager = buildingInput.Manager,
            Mobile = buildingInput.Mobile,
            Code = ranCode
        };

        var message = "";
        var isSuccess = false;
        try
        {
            var result = await _building.Create(building);
            message = ranCode.ToString();
            isSuccess = true;
        }
        catch (Exception ex)
        {
            message = ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message)
                ? ex.InnerException.Message
                : ex.Message;
        }

        return new BuildingInfoDto
        {
            IsSuccess = isSuccess,
            Message = message
        };
    }
}
