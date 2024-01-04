using Microsoft.AspNetCore.Mvc;
using Firebase.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using Firebase.API.Application.Models.Request;
using Firebase.Api.Application.Models.Response;
using Firebase.Platform.Auth.Services.Models.Result;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using AuthModelRequest = Firebase.Platform.Auth.Services.Models.Request;

namespace Firebase.API.Application.Controllers;

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
