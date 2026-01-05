using Accounts.Infrastructure.Handlers;
using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarPlatformCommon.Requests;
using SolarPlatformCommon.Responses;

namespace Accounts;

public class Startup : NomirunModuleStartup
{
    public Startup(IConfiguration configuration) : base(configuration)
    { }

    protected override void RegisterModuleServices(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<GetAccountDataRequest, AccountDataResponse>, GetAccountDataHandler>();
    }
}