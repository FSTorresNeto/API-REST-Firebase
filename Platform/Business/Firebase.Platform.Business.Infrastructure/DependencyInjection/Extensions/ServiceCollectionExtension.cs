using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Infrastructure.DependencyInjection;

namespace Firebase.Platform.Business.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddScopedBusinessFactories(this IServiceCollection services)
    {
        TrashServiceCollection.AddScopedFactories(services);
        DepositServiceCollection.AddScopedFactories(services);
    }

}
