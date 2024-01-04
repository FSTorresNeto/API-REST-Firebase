using Dapper;
using Microsoft.Data.SqlClient;
using Firebase.Platform.Business.Entity.Models;
using Firebase.Platform.Business.Repository.Interfaces;
using Firebase.Platform.Common.Entity;

namespace Firebase.Platform.Business.Repository;

public class TrashRepository : ITrashRepository
{
    private readonly Settings _settings;

    public TrashRepository(Settings settings)
    {
        _settings = settings;
    }

    public Trash GetById(long trashId)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);

        try
        {
            Trash getTrashById = connection.QueryFirst<Trash>("SELECT * FROM Trash WHERE TrashId = @Id", new { Id = trashId });

            return getTrashById;
        }
        catch
        {
            return null;
        }
    }

    public List<Trash> GetAll()
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        IEnumerable<Trash> producList = connection.Query<Trash>("SELECT * FROM Trash");

        return producList.ToList<Trash>();
    }

    public void SaveNewTrash(Trash trash)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("INSERT INTO Trash (Name, Value) VALUES (@Name, @Value)", trash);
    }

    public void DeleteTrash(long trashId)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("DELETE FROM Trash WHERE TrashId = @TrashId", new { TrashId = trashId });
    }

    public void UpdateTrash(Trash trash)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("UPDATE Trash SET Name = @Name, Value = @Value WHERE TrashId = @TrashId", trash);
    }
}