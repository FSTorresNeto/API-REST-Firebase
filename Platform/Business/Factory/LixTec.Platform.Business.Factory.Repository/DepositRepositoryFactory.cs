using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Factory.Repository.Interfaces;
using LixTec.Platform.Business.Repository.Interfaces;

namespace LixTec.Platform.Business.Factory.Repository;

public class DepositRepositoryFactory : IDepositRepositoryFactory
{
    private IServiceProvider _provider;

    public DepositRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDepositRepository Create() => _provider.GetService<IDepositRepository>();
}
