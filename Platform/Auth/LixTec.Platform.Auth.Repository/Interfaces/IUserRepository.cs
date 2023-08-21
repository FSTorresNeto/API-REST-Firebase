using LixTec.Platform.Auth.Entity.Models;

namespace LixTec.Platform.Auth.Repository.Interfaces;

public interface IUserRepository
{
    public User GetByLogin(string login);
    public void SaveNewUser(User user);

}