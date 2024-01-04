using Microsoft.Extensions.DependencyInjection;
using Firebase.Platform.Business.Factory.Service.Interfaces;
using Firebase.Platform.Business.Service.Interfaces;

namespace Firebase.Platform.Business.Factory.Service;

public class TrashServiceFactory : ITrashServiceFactory
{
    private IServiceProvider _provider;

    public TrashServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ITrashService Create() => _provider.GetService<ITrashService>();
}
