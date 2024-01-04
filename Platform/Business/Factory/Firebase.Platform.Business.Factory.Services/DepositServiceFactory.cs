using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Factory.Service.Interfaces;
using Firebase.Platform.Business.Service.Interfaces;

namespace Firebase.Platform.Business.Factory.Service;

public class DepositServiceFactory : IDepositServiceFactory
{
    private IServiceProvider _provider;

    public DepositServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDepositService Create() => _provider.GetService<IDepositService>();
}
