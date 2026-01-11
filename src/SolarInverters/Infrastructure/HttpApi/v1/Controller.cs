using Microsoft.AspNetCore.Authorization;
using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarInverters.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SolarInverters.Infrastructure.HttpApi.v1;

[Route("api")]
public class SolarInvertersController : NomirunApiController
{
    private readonly ILogger<SolarInvertersController> _logger;

    public SolarInvertersController(ILogger<SolarInvertersController> logger) : base(logger)
    {
        _logger = logger;
    }

    [Authorize]
    [HttpGet("solarInverters/{solarInverterId:long}/status")]
    public async Task<IActionResult> GetSolarInverterStatus([FromRoute] long solarInverterId)
    {
        return Ok(new SolarInvereterOutput
        {
            AcOutputPowerKw = 4.8,
            AcVoltageV = 230,
            AcCurrentA = 20.9,
            EfficiencyPercent = 97.5,
            EnergyTodayKwh = 28.4,
            TotalEnergyKwh = 2540,
            Status = "Connected"
        });
    }

    [Authorize]
    [HttpPost("solarInverters/{solarInverterId:long}/reading")]
    public async Task<IActionResult> SolarInvertersDemoAction([FromRoute] long solarInverterId, [FromBody] SolarInverterReading solarInverterReading)
    {
        return Created();
    }
}
