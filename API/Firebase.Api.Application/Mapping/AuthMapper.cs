using Firebase.API.Application.Models.Request;
using AuthModelRequest = Firebase.Platform.Auth.Services.Models.Request;

namespace Firebase.Api.Application.Mapping;

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
