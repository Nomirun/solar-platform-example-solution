using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarInverters.Infrastructure.Handlers;
using SolarPlatformCommon.Requests;
using SolarPlatformCommon.Responses;

namespace SolarInverters;

public class Startup : NomirunModuleStartup
{
    public Startup(IConfiguration configuration) : base(configuration)
    { }

    protected override void RegisterModuleServices(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<GetSolarInverterMonthlyPowerReportRequest, SolarInvereterMonthyDataResponse>, SolarInverterMonthlyReportHandler>();
    }
}