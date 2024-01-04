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
