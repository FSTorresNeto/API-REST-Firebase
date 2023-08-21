using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Infrastructure.DependencyInjection;

namespace LixTec.Platform.Business.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddScopedBusinessFactories(this IServiceCollection services)
    {
        TrashServiceCollection.AddScopedFactories(services);
        DepositServiceCollection.AddScopedFactories(services);
    }

}
