using Firebase.Platform.Auth.Entity.Models;

namespace Firebase.Platform.Auth.Repository.Interfaces;

public interface IUserRepository
{
    public User GetByLogin(string login);
    public void SaveNewUser(User user);

}