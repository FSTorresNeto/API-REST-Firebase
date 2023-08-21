using LixTec.API.Application.Models.Request;
using AuthModelRequest = LixTec.Platform.Auth.Services.Models.Request;

namespace LixTec.Api.Application.Mapping;

public class AuthMapper
{
    public AuthModelRequest.AuthenticateRequest Map(AuthenticateRequest authenticateRequest)
    {
        return new AuthModelRequest.AuthenticateRequest()
        {
            Login = authenticateRequest.Login,
            Password = authenticateRequest.Password
        };
    }
}
