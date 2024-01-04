using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Factory.Service;
using Firebase.Platform.Business.Factory.Repository.Interfaces;
using Firebase.Platform.Business.Factory.Service.Interfaces;
using Firebase.Platform.Business.Repository.Interfaces;
using Firebase.Platform.Business.Service;
using Firebase.Platform.Business.Service.Interfaces;
using Firebase.Platform.Business.Repository;
using Firebase.Platform.Business.Factory.Repository;

namespace Firebase.Platform.Business.Infrastructure.DependencyInjection;

internal class DepositServiceCollection
{
    public static void AddScopedFactories(IServiceCollection services)
    {
        services.AddScoped<IDepositService, DepositService>();
        services.AddScoped<IDepositServiceFactory, DepositServiceFactory>();
        services.AddScoped<IDepositRepository, DepositRepository>();
        services.AddScoped<IDepositRepositoryFactory, DepositRepositoryFactory>();
    }
}
