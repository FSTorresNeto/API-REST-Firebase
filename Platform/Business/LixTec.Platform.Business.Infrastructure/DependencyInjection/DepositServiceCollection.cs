using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Factory.Service;
using LixTec.Platform.Business.Factory.Repository.Interfaces;
using LixTec.Platform.Business.Factory.Service.Interfaces;
using LixTec.Platform.Business.Repository.Interfaces;
using LixTec.Platform.Business.Service;
using LixTec.Platform.Business.Service.Interfaces;
using LixTec.Platform.Business.Repository;
using LixTec.Platform.Business.Factory.Repository;

namespace LixTec.Platform.Business.Infrastructure.DependencyInjection;

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
