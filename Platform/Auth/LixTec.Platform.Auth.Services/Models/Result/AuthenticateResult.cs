using LixTec.Platform.Auth.Entity.Models;

namespace LixTec.Platform.Auth.Services.Models.Result;
#nullable enable

public class AuthenticateResult
{
    public string? JwtToken { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? DepositsTotalValue { get; set; }
}