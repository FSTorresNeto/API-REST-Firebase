using Firebase.Platform.Auth.Services.Models.Request;

namespace Firebase.Platform.Auth.Service.Interfaces
{
    public interface IUserService
    {
        public void SaveNewUserAsync(SaveNewUserRequest saveNewUserRequest);
        public void UpdateUser(UpdateUserDataRequest updateUserRequest);
    }
}