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

internal class TrashServiceCollection
{
    public static void AddScopedFactories(IServiceCollection services)
    {
        services.AddScoped<ITrashService, TrashService>();
        services.AddScoped<ITrashServiceFactory, TrashServiceFactory>();
        services.AddScoped<ITrashRepository, TrashRepository>();
        services.AddScoped<ITrashRepositoryFactory, TrashRepositoryFactory>();
    }
}
