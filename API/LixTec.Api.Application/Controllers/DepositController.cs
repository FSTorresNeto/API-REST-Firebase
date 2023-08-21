using Microsoft.AspNetCore.Mvc;
using LixTec.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using LixTec.API.Application.Models.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LixTec.Platform.Business.Factory.Service.Interfaces;
using AuthModelRequest = LixTec.Platform.Business.Services.Models.Request;

namespace LixTec.API.Application.Controllers;

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
