using LixTec.Platform.Auth.Entity;
using LixTec.Platform.Auth.Services.Models.Request;
using LixTec.Platform.Auth.Services.Models.Result;

namespace LixTec.Platform.Auth.Service.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthenticateResult> AuthenticateAsync(AuthenticateRequest authenticateRequest);
    }
}