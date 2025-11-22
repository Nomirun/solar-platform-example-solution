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

    [SwaggerOperation(
        Summary = "Create a new solar inverter reading",
        Description = "Creates a new solar inverter reading with the provided data. The action accepts a solar inverter ID and a solar inverter reading object as parameters. The solar inverter reading object should contain relevant data such as AC output power in kW, AC voltage in V, AC current in A, efficiency in percentage, energy generated today in kWh, and total energy generated in kWh. The action returns a 201 Created response with the created solar inverter reading.",
        OperationId = nameof(SolarInvertersDemoAction),
        Tags = new[] { "SolarInverters" }
    )]
    [HttpPost("solarInverters/{solarInverterId:long}/reading")]
    public async Task<IActionResult> SolarInvertersDemoAction([FromRoute] long solarInverterId, [FromBody] SolarInverterReading solarInverterReading)
    {
        return Created();
    }
}
