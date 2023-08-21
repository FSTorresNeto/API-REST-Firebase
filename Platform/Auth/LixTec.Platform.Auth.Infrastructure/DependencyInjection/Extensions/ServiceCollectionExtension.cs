using Microsoft.Extensions.DependencyInjection;

namespace LixTec.Platform.Auth.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddScopedAuthFactories(this IServiceCollection services)
    {
        AuthServiceCollection.AddScopedFactories(services);
        UserServiceCollection.AddScopedFactories(services);
    }

}
