using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reports.Models;
using SolarPlatformCommon.Requests;
using SolarPlatformCommon.Responses;

namespace Reports.Infrastructure.HttpApi.v1;

[Route("api")]
public class ReportsController : NomirunApiController
{
    private readonly ILogger<ReportsController> _logger;
    private readonly IMediate _mediate;

    public ReportsController(ILogger<ReportsController> logger, IMediate mediate) : base(logger)
    {
        _logger = logger;
        _mediate = mediate;
    }

    [HttpGet("reports/{reportId:int}")]
    public async Task<IActionResult> Report([FromRoute] int reportId, [FromQuery] long accountId)
    {
        var monthlyReport = new MonthlyReport { Title = "Monthly report september 2025" };

        var accountDetails =
            await _mediate.Send<GetAccountDataRequest, AccountDataResponse>(
                new GetAccountDataRequest
                {
                    AccountId = 1
                });

        var solarInverterData =
            await _mediate.Send<GetSolarInverterMonthlyPowerReportRequest, SolarInvereterMonthyDataResponse>(
                new GetSolarInverterMonthlyPowerReportRequest
                {
                    SolarInverterId = accountDetails.SolarInverterIds.FirstOrDefault(), Month = 9, Year = 2025
                });

        monthlyReport.MonthlyPowerKwh = solarInverterData.MonthlyPowerKw;
        monthlyReport.SolarInverterId = solarInverterData.SolarInverterId;
        monthlyReport.OwnerName = $"{accountDetails.FirstName} {accountDetails.LastName}";

        return Ok(monthlyReport);
    }
}
