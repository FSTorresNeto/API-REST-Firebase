namespace Firebase.Platform.Auth.Services.Models.Request;

public class AuthenticateRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}