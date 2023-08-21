namespace LixTec.API.Application.Models.Request;

public class GenerateDepositRequest
{
    public string UserId { get; set; }
    public string HashCode { get; set; }
    public string DepositsTotalValue { get; set; }
}