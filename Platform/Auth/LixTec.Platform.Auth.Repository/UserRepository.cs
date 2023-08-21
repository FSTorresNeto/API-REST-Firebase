using Dapper;
using Microsoft.Data.SqlClient;
using LixTec.Platform.Auth.Entity.Models;
using LixTec.Platform.Auth.Repository.Interfaces;
using LixTec.Platform.Common.Entity;

namespace LixTec.Platform.Auth.Repository;

public class UserRepository : IUserRepository
{
    private readonly Settings _settings;

    public UserRepository(Settings settings)
    {
        _settings = settings;
    }

    public User GetByLogin(string login)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        try
        {
            User user = connection.QueryFirst<User>("SELECT * FROM [User] WHERE Login = @Login", new { Login = login });

            return user;
        }
        catch
        {
            return null;
        }
    }

    public void SaveNewUser(User user)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("INSERT INTO [User] ([Login], [Password]) VALUES (@Login, @Password)", user);
    }

}