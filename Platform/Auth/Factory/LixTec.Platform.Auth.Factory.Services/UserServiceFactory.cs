using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Auth.Factory.Service.Interfaces;
using LixTec.Platform.Auth.Service.Interfaces;

namespace LixTec.Platform.Auth.Factory.Service;

public class UserServiceFactory : IUserServiceFactory
{
    private IServiceProvider _provider;

    public UserServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IUserService Create() => _provider.GetService<IUserService>();
}
