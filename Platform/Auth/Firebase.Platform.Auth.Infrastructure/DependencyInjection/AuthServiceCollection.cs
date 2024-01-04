using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Auth.Factory.Service;
using Firebase.Platform.Auth.Factory.Repository.Interfaces;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using Firebase.Platform.Auth.Repository.Interfaces;
using Firebase.Platform.Auth.Service;
using Firebase.Platform.Auth.Service.Interfaces;
using Firebase.Platform.Auth.Repository;
using Firebase.Platform.Auth.Factory.Repository;

namespace Firebase.Platform.Auth.Infrastructure.DependencyInjection;

internal class AuthServiceCollection
{
    public static void AddScopedFactories(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthServiceFactory, AuthServiceFactory>();
    }
}
