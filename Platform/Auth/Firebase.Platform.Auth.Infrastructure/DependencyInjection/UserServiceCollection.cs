using Firebase.Platform.Auth.Repository;
using Firebase.Platform.Auth.Factory.Repository;
using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Auth.Repository.Interfaces;
using Firebase.Platform.Auth.Factory.Repository.Interfaces;
using Firebase.Platform.Auth.Service.Interfaces;
using Firebase.Platform.Auth.Service;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using Firebase.Platform.Auth.Factory.Service;

namespace Firebase.Platform.Auth.Infrastructure.DependencyInjection;

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
