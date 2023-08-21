using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Auth.Factory.Repository.Interfaces;
using LixTec.Platform.Auth.Repository.Interfaces;

namespace LixTec.Platform.Auth.Factory.Repository;

public class UserRepositoryFactory : IUserRepositoryFactory
{
    private IServiceProvider _provider;

    public UserRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IUserRepository Create() => _provider.GetService<IUserRepository>();
}
