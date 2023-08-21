using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Auth.Factory.Service.Interfaces;
using LixTec.Platform.Auth.Service.Interfaces;

namespace LixTec.Platform.Auth.Factory.Service;

public class AuthServiceFactory : IAuthServiceFactory
{
    private IServiceProvider _provider;

    public AuthServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IAuthService Create() => _provider.GetService<IAuthService>();
}
