using Firebase.Platform.Business.Common;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Firebase.Platform.Business.Factory.Repository.Interfaces;
using Firebase.Platform.Business.Service.Interfaces;
using Firebase.Platform.Business.Service.Mapping;
using Firebase.Platform.Business.Services.Models.Result;
using Firebase.Platform.Common.Entity;
namespace Firebase.Platform.Business.Service;

public class TrashService : ITrashService
{
    private readonly TrashMapper _trashMapper;
    private readonly ITrashRepositoryFactory _trashRepositoryFactory;
    private readonly Settings _settings;
    private readonly FirestoreDb _fireStoreDb;
    private readonly string ProjectId = "Firebase-dac2e";

    public TrashService(ITrashRepositoryFactory trashRepositoryFactory, Settings settings)
    {
        _trashMapper = new TrashMapper();
        _trashRepositoryFactory = trashRepositoryFactory;
        _settings = settings;
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "./Firebase-dac2e.json");
        _fireStoreDb = FirestoreDb.Create(ProjectId);
    }

    public GetTrashByIdResult GetById(long trashId)
    {
        throw new BusinessException("Não implementado");
    }

    public async Task<List<GetTrashListResult>> GetAllAsync()
    {
        Query userQuery = _fireStoreDb.Collection("Trash");

        QuerySnapshot userQuerySnapshot = await userQuery.GetSnapshotAsync();

        List<GetTrashListResult> resultList = new List<GetTrashListResult>();

        foreach (DocumentSnapshot documentSnapshot in userQuerySnapshot.Documents)
        {
            if (documentSnapshot.Exists)
            {
                GetTrashListResult getTrashListResult = new GetTrashListResult
                {
                    Name = documentSnapshot.GetValue<string>("name"),
                    Number = documentSnapshot.GetValue<string>("number"),
                    Street = documentSnapshot.GetValue<string>("street")
                };

                resultList.Add(getTrashListResult);
            }
        }
        if (resultList.Count != 0)
        {
            return resultList;
        }
        else
        {

            throw new BusinessException("Ocorreu um erro inesperado ou não existem Lixeiras");
        }

    }
}
