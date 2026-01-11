using Accounts.Models;
using Microsoft.AspNetCore.Authorization;
using Nomirun.Sdk.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Accounts.Infrastructure.HttpApi.v1;

[Route("api")]
public class AccountsController : NomirunApiController
{
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(ILogger<AccountsController> logger) : base(logger)
    {
        _logger = logger;
    }

    [HttpGet("accounts/{accountId}")]
    [ProducesResponseType(typeof(Account), 200)]
    public async Task<IActionResult> GetAccount([FromRoute] long accountId)
    {
        return Ok(new Account
        {
            FirstName = "Miha",
            LastName = "Jakovac",
            SolarInverterIds = new List<long>()
            {
                100
            }
        });
    }
}
