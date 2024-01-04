using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Factory.Repository.Interfaces;
using Firebase.Platform.Business.Repository.Interfaces;

namespace Firebase.Platform.Business.Factory.Repository;

public class TrashRepositoryFactory : ITrashRepositoryFactory
{
    private IServiceProvider _provider;

    public TrashRepositoryFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ITrashRepository Create() => _provider.GetService<ITrashRepository>();
}
