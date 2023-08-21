using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Auth.Factory.Service;
using LixTec.Platform.Auth.Factory.Repository.Interfaces;
using LixTec.Platform.Auth.Factory.Service.Interfaces;
using LixTec.Platform.Auth.Repository.Interfaces;
using LixTec.Platform.Auth.Service;
using LixTec.Platform.Auth.Service.Interfaces;
using LixTec.Platform.Auth.Repository;
using LixTec.Platform.Auth.Factory.Repository;

namespace LixTec.Platform.Auth.Infrastructure.DependencyInjection;

internal class AuthServiceCollection
{
    public static void AddScopedFactories(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthServiceFactory, AuthServiceFactory>();
    }
}
