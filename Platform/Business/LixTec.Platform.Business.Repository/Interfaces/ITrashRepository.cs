using LixTec.Platform.Business.Entity.Models;

namespace LixTec.Platform.Business.Repository.Interfaces;

public interface ITrashRepository
{
    public Trash GetById(long trashId);
    public List<Trash> GetAll();
}