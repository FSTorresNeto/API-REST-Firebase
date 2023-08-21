using LixTec.API.Application.Models.Request;
using AuthModelRequest = LixTec.Platform.Auth.Services.Models.Request;

namespace LixTec.Api.Application.Mapping;

public class UserMapper
{
    public AuthModelRequest.SaveNewUserRequest Map(SaveNewUserRequest saveNewUserRequest)
    {
        return new AuthModelRequest.SaveNewUserRequest()
        {
            Email = saveNewUserRequest.Email,
            Password = saveNewUserRequest.Password,
            Name = saveNewUserRequest.Name,
            PhoneNumber = saveNewUserRequest.PhoneNumber,
        };
    }

    public AuthModelRequest.UpdateUserDataRequest Map(UpdateUserDataRequest saveNewUserRequest)
    {
        return new AuthModelRequest.UpdateUserDataRequest()
        {
            UserId = saveNewUserRequest.UserId,
            Name = saveNewUserRequest.Name,
            Email = saveNewUserRequest.Email,
            PhoneNumber = saveNewUserRequest.PhoneNumber,
        };
    }
}
