﻿#nullable disable

namespace Farabeh.MyBuilding.Api.Core.Domain.Buildings.Dtos.Outputs;

public class BuildingInfoDto
{
    public List<BuildingDto> Buildings { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
