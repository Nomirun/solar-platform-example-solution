using Microsoft.Extensions.Configuration;
using Nomirun.Sdk.Abstractions.Interfaces;
using SolarPlatformCommon.Requests;
using SolarPlatformCommon.Responses;

namespace Accounts.Infrastructure.Handlers
{
    public class GetAccountDataHandler: IRequestHandler<GetAccountDataRequest, AccountDataResponse>
    {
        private readonly IConfiguration _configuration;

        public GetAccountDataHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<AccountDataResponse> Handle(GetAccountDataRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AccountDataResponse
            {
                FirstName = "Miha", LastName = "Jakovac", SolarInverterIds = new List<long>(){100}
            });
        }
    }
}