using Microsoft.AspNetCore.Mvc;
using Firebase.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using Firebase.API.Application.Models.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using AuthModelRequest = Firebase.Platform.Auth.Services.Models.Request;

namespace Firebase.API.Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserServiceFactory _userServiceFactory;
    private readonly UserMapper _userMapper;

    public UserController(IUserServiceFactory userServiceFactory)
    {
        _userServiceFactory = userServiceFactory;
        _userMapper = new UserMapper();
    }


    [HttpPost()]
    public IActionResult CreateNewUser([FromBody] SaveNewUserRequest saveNewUserRequest)
    {
        AuthModelRequest.SaveNewUserRequest authModelRequest = _userMapper.Map(saveNewUserRequest);
        _userServiceFactory.Create().SaveNewUserAsync(authModelRequest);
        return NoContent();
    }



    [HttpPost()]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult UpdateUserData([FromBody] UpdateUserDataRequest updateUserRequest)
    {
        AuthModelRequest.UpdateUserDataRequest authModelRequest = _userMapper.Map(updateUserRequest);
        _userServiceFactory.Create().UpdateUser(authModelRequest);
        return NoContent();
    }
}
