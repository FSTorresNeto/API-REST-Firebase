using Microsoft.AspNetCore.Mvc;
using Firebase.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using Firebase.API.Application.Models.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Firebase.Platform.Business.Factory.Service.Interfaces;
using AuthModelRequest = Firebase.Platform.Business.Services.Models.Request;

namespace Firebase.API.Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DepositController : ControllerBase
{
    private readonly IDepositServiceFactory _depositServiceFactory;
    private readonly DepositMapper _depositMapper;

    public DepositController(IDepositServiceFactory depositServiceFactory)
    {
        _depositServiceFactory = depositServiceFactory;
        _depositMapper = new DepositMapper();
    }

    [HttpPost()]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GenerateDeposit([FromBody] GenerateDepositRequest generateDepositRequest)
    {
        AuthModelRequest.GenerateDepositRequest authModelRequest = _depositMapper.Map(generateDepositRequest);
        _depositServiceFactory.Create().GenerateDeposit(authModelRequest);
        return NoContent();
    }
}
