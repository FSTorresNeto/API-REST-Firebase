using Dapper;
using Microsoft.Data.SqlClient;
using LixTec.Platform.Business.Entity.Models;
using LixTec.Platform.Business.Repository.Interfaces;
using LixTec.Platform.Common.Entity;

namespace LixTec.Platform.Business.Repository;

public class DepositRepository : IDepositRepository
{
    private readonly Settings _settings;

    public DepositRepository(Settings settings)
    {
        _settings = settings;
    }

    public Trash GetById(long DepositId)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);

        try
        {
            Trash getDepositById = connection.QueryFirst<Trash>("SELECT * FROM Deposit WHERE DepositId = @Id", new { Id = DepositId });

            return getDepositById;
        }
        catch
        {
            return null;
        }
    }

    public List<Trash> GetAll()
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        IEnumerable<Trash> producList = connection.Query<Trash>("SELECT * FROM Deposit");

        return producList.ToList<Trash>();
    }

    public void SaveNewDeposit(Trash Deposit)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("INSERT INTO Deposit (Name, Value) VALUES (@Name, @Value)", Deposit);
    }

    public void DeleteDeposit(long DepositId)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("DELETE FROM Deposit WHERE DepositId = @DepositId", new { DepositId = DepositId });
    }

    public void UpdateDeposit(Trash Deposit)
    {
        using var connection = new SqlConnection(_settings.ConnectionStrings["DefaultConnection"]);
        connection.Execute("UPDATE Deposit SET Name = @Name, Value = @Value WHERE DepositId = @DepositId", Deposit);
    }
}