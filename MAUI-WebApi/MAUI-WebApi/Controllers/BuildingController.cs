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

    [HttpGet("~/api/Building/Create")]
    public async Task<BuildingInfoDto> GetBuilding([FromQuery] string name)
    {
        var building = new BuildingDto { Name = name };
        var message = "";
        var isSuccess = false;
        try
        {
            var result = await _building.Create(building);
            message = $"Creaed with id {result}.";
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

    [HttpPost("~/api/Building/Create")]
    public async Task<BuildingInfoDto> CreateBuilding([FromBody] BuildingInputDto buildingInput)
    {
        var building = new BuildingDto { Name = buildingInput.Name };
        var message = "";
        var isSuccess = false;
        try
        {
            var result = await _building.Create(building);
            message = $"Creaed with id {result}.";
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
