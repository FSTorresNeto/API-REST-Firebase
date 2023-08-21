using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Factory.Repository.Interfaces;
using LixTec.Platform.Business.Repository.Interfaces;

namespace LixTec.Platform.Business.Factory.Repository;

public class TrashRepositoryFactory : ITrashRepositoryFactory
{
    private IServiceProvider _provider;

    public TrashRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ITrashRepository Create() => _provider.GetService<ITrashRepository>();
}
