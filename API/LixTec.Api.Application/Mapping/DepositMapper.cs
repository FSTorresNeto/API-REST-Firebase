using LixTec.API.Application.Models.Request;
using BusinessModelRequest = LixTec.Platform.Business.Services.Models.Request;

namespace LixTec.Api.Application.Mapping;

public class DepositMapper
{
    public BusinessModelRequest.GenerateDepositRequest Map(GenerateDepositRequest generateDepositsRequest)
    {
        return new BusinessModelRequest.GenerateDepositRequest()
        {
            UserId = generateDepositsRequest.UserId,
            HashCode = generateDepositsRequest.HashCode,
            DepositsTotalValue = generateDepositsRequest.DepositsTotalValue,
        };
    }
}
