using Microsoft.AspNetCore.Mvc;
using LixTec.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using LixTec.API.Application.Models.Request;
using LixTec.Api.Application.Models.Response;
using LixTec.Platform.Auth.Services.Models.Result;
using LixTec.Platform.Auth.Factory.Service.Interfaces;
using AuthModelRequest = LixTec.Platform.Auth.Services.Models.Request;

namespace LixTec.API.Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServiceFactory _authServiceFactory;
    private readonly AuthMapper _authMapper;
    public AuthController(IAuthServiceFactory authServiceFactory)
    {
        _authServiceFactory = authServiceFactory;
        _authMapper = new AuthMapper();
    }

    [AllowAnonymous]
    [HttpPost()]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest AuthenticateRequest)
    {
        AuthModelRequest.AuthenticateRequest authModelRequest = _authMapper.Map(AuthenticateRequest);

        AuthenticateResult result = await _authServiceFactory.Create().AuthenticateAsync(authModelRequest);

        Response response = ResponseMapper.Map(true, result, null);

        return Ok(response);
    }
}
