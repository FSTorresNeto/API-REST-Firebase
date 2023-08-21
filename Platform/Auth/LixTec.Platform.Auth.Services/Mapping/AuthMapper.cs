using LixTec.Platform.Auth.Entity.Models;
using LixTec.Platform.Auth.Services.Models.Result;

namespace LixTec.Platform.Auth.Service.Mapping;

public class AuthMapper
{

    public AuthenticateResult Map(string jwtToken, User user, string DocumentSnapshot)
    {
        return new AuthenticateResult
        {
            JwtToken = jwtToken,
            UserId = DocumentSnapshot,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            DepositsTotalValue = user.DepositsTotalValue,

        };
    }

}
