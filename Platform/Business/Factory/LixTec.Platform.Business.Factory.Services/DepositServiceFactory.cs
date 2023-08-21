using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Factory.Service.Interfaces;
using LixTec.Platform.Business.Service.Interfaces;

namespace LixTec.Platform.Business.Factory.Service;

public class DepositServiceFactory : IDepositServiceFactory
{
    private IServiceProvider _provider;

    public DepositServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDepositService Create() => _provider.GetService<IDepositService>();
}
