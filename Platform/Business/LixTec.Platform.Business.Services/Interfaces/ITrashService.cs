using LixTec.Platform.Business.Entity;
using LixTec.Platform.Business.Services.Models.Result;

namespace LixTec.Platform.Business.Service.Interfaces
{
    public interface ITrashService
    {
        GetTrashByIdResult GetById(long trashId);
        public Task<List<GetTrashListResult>> GetAllAsync();
    }
}