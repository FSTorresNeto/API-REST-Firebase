using Newtonsoft.Json;
using Google.Cloud.Firestore;
using LixTec.Platform.Common.Entity;
using LixTec.Platform.Auth.Entity.Models;
using LixTec.Platform.Auth.Service.Interfaces;
using LixTec.Platform.Auth.Services.Models.Request;
using LixTec.Platform.Auth.Factory.Repository.Interfaces;
using LixTec.Platform.Auth.Common;

namespace LixTec.Platform.Auth.Service;

public class UserService : IUserService
{

    private readonly IUserRepositoryFactory _userRepositoryFactory;
    private readonly Settings _settings;
    private readonly FirestoreDb _fireStoreDb;
    private readonly string ProjectId = "lixtec-dac2e";

    public UserService(IUserRepositoryFactory userRepositoryFactory, Settings settings)
    {
        _userRepositoryFactory = userRepositoryFactory;
        _settings = settings;
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "./lixtec-dac2e.json");
        _fireStoreDb = FirestoreDb.Create(ProjectId);
    }

    public async void SaveNewUserAsync(SaveNewUserRequest saveNewUserRequest)
    {

        Query userQuery = _fireStoreDb.Collection("User");

        QuerySnapshot userQuerySnapshot = await userQuery.GetSnapshotAsync();

        List<User> listUser = new List<User>();

        foreach (DocumentSnapshot documentSnapshot in userQuerySnapshot.Documents)
        {
            if (documentSnapshot.Exists)
            {
                Dictionary<string, object> user = documentSnapshot.ToDictionary();

                string result = JsonConvert.SerializeObject(user);

                User users = JsonConvert.DeserializeObject<User>(result);

                if (users != null)
                {
                    if (saveNewUserRequest.Email == users.Email)
                    {
                        throw new AuthException("Usuário já existe");
                    }
                }
            }
        }

        CollectionReference collectionReference = _fireStoreDb.Collection("User");

        await collectionReference.AddAsync(saveNewUserRequest);
    }


    public async void UpdateUser(UpdateUserDataRequest updateUserRequest)
    {

        CollectionReference userRef = _fireStoreDb.Collection("User");

        string userId = updateUserRequest.UserId;

        DocumentReference userDoc = userRef.Document(userId);

        Dictionary<string, object> updateData = new Dictionary<string, object>
        {
            { "name", updateUserRequest.Name },
            { "email", updateUserRequest.Email},
            { "phoneNumber", updateUserRequest.PhoneNumber },
        };

        await userDoc.UpdateAsync(updateData);
    }
}
