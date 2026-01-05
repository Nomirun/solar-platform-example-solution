using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Reports;

public class Startup : NomirunModuleStartup
{
    public Startup(IConfiguration configuration) : base(configuration)
    { }

    protected override void RegisterModuleServices(IServiceCollection services)
    {
    }
}