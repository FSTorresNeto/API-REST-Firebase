namespace LixTec.Platform.Auth.Services.Models.Request;

public class UpdateUserDataRequest
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DepositsTotalValue { get; set; }
}