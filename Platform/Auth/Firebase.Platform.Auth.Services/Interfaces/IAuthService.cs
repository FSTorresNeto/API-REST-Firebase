using Firebase.Platform.Auth.Entity;
using Firebase.Platform.Auth.Services.Models.Request;
using Firebase.Platform.Auth.Services.Models.Result;

namespace Firebase.Platform.Auth.Service.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthenticateResult> AuthenticateAsync(AuthenticateRequest authenticateRequest);
    }
}