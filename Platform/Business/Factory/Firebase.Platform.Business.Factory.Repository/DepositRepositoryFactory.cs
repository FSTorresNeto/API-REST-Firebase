using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Factory.Repository.Interfaces;
using Firebase.Platform.Business.Repository.Interfaces;

namespace Firebase.Platform.Business.Factory.Repository;

public class DepositRepositoryFactory : IDepositRepositoryFactory
{
    private IServiceProvider _provider;

    public DepositRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDepositRepository Create() => _provider.GetService<IDepositRepository>();
}
