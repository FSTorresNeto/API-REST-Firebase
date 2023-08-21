using LixTec.Platform.Business.Services.Models.Request;

namespace LixTec.Platform.Business.Service.Interfaces
{
    public interface IDepositService
    {
        public void GenerateDeposit(GenerateDepositRequest generateDepositRequest);
    }
}