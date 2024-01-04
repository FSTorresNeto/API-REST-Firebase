using Firebase.Platform.Business.Entity;
using Firebase.Platform.Business.Services.Models.Result;

namespace Firebase.Platform.Business.Service.Interfaces
{
    public interface ITrashService
    {
        GetTrashByIdResult GetById(long trashId);
        public Task<List<GetTrashListResult>> GetAllAsync();
    }
}