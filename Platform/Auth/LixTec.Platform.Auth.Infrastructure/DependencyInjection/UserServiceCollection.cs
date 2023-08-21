using LixTec.Platform.Auth.Repository;
using LixTec.Platform.Auth.Factory.Repository;
using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Auth.Repository.Interfaces;
using LixTec.Platform.Auth.Factory.Repository.Interfaces;
using LixTec.Platform.Auth.Service.Interfaces;
using LixTec.Platform.Auth.Service;
using LixTec.Platform.Auth.Factory.Service.Interfaces;
using LixTec.Platform.Auth.Factory.Service;

namespace LixTec.Platform.Auth.Infrastructure.DependencyInjection;

internal class UserServiceCollection
{
    public static void AddScopedFactories(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserServiceFactory, UserServiceFactory>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRepositoryFactory, UserRepositoryFactory>();
    }
}
