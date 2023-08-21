using Microsoft.Extensions.DependencyInjection;
using LixTec.Platform.Business.Factory.Service.Interfaces;
using LixTec.Platform.Business.Service.Interfaces;

namespace LixTec.Platform.Business.Factory.Service;

public class TrashServiceFactory : ITrashServiceFactory
{
    private IServiceProvider _provider;

    public TrashServiceFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ITrashService Create() => _provider.GetService<ITrashService>();
}
