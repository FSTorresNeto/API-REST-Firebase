using Newtonsoft.Json;
using Google.Cloud.Firestore;
using LixTec.Platform.Common.Entity;
using LixTec.Platform.Business.Service.Interfaces;
using LixTec.Platform.Business.Factory.Repository.Interfaces;
using LixTec.Platform.Business.Services.Models.Request;

namespace LixTec.Platform.Business.Service;

public class DepositService : IDepositService
{

    private readonly IDepositRepositoryFactory _DepositRepositoryFactory;
    private readonly Settings _settings;
    private readonly FirestoreDb _fireStoreDb;
    private readonly string ProjectId = "lixtec-dac2e";

    public DepositService(IDepositRepositoryFactory DepositRepositoryFactory, Settings settings)
    {
        _DepositRepositoryFactory = DepositRepositoryFactory;
        _settings = settings;
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "./lixtec-dac2e.json");
        _fireStoreDb = FirestoreDb.Create(ProjectId);
    }

    public async void GenerateDeposit(GenerateDepositRequest depositRequest)
    {

        int startIndex = depositRequest.DepositsTotalValue.IndexOf("depositsTotalValue:") + "depositsTotalValue:".Length;

        int endIndex = depositRequest.DepositsTotalValue.IndexOf(",", startIndex);

        string depositValue = depositRequest.DepositsTotalValue.Substring(startIndex, endIndex - startIndex);

        int numericValue = int.Parse(depositValue);
        int actualDepositsValue = int.Parse(depositRequest.DepositsTotalValue);

        CollectionReference DepositRef = _fireStoreDb.Collection("Deposit");

        string UserId = depositRequest.UserId;

        DocumentReference DepositDoc = DepositRef.Document(UserId);

        Dictionary<string, object> updateData = new Dictionary<string, object>
        {
            { "depositsTotalValue", (numericValue + actualDepositsValue).ToString() },
        };

        await DepositDoc.UpdateAsync(updateData);
    }
}