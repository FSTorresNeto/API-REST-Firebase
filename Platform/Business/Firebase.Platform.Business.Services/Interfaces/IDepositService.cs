using Firebase.Platform.Business.Services.Models.Request;

namespace Firebase.Platform.Business.Service.Interfaces
{
    public interface IDepositService
    {
        public void GenerateDeposit(GenerateDepositRequest generateDepositRequest);
    }
}