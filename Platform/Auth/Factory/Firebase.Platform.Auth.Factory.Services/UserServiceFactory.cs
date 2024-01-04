using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using Firebase.Platform.Auth.Service.Interfaces;

namespace Firebase.Platform.Auth.Factory.Service;

public class UserServiceFactory : IUserServiceFactory
{
    private IServiceProvider _provider;

    public UserServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IUserService Create() => _provider.GetService<IUserService>();
}
