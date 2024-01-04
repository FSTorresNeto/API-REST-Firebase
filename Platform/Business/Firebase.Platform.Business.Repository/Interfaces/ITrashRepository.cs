using Firebase.Platform.Business.Entity.Models;

namespace Firebase.Platform.Business.Repository.Interfaces;

public interface ITrashRepository
{
    public Trash GetById(long trashId);
    public List<Trash> GetAll();
}