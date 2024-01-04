using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Auth.Factory.Repository.Interfaces;
using Firebase.Platform.Auth.Repository.Interfaces;

namespace Firebase.Platform.Auth.Factory.Repository;

public class UserRepositoryFactory : IUserRepositoryFactory
{
    private IServiceProvider _provider;

    public UserRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IUserRepository Create() => _provider.GetService<IUserRepository>();
}
