using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Auth.Factory.Service.Interfaces;
using Firebase.Platform.Auth.Service.Interfaces;

namespace Firebase.Platform.Auth.Factory.Service;

public class AuthServiceFactory : IAuthServiceFactory
{
    private IServiceProvider _provider;

    public AuthServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IAuthService Create() => _provider.GetService<IAuthService>();
}
