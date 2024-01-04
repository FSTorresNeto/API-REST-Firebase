namespace Firebase.API.Application.Models.Request;

public class SaveNewUserRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool Terms { get; set; }
}