
using LixTec.Platform.Business.Entity.Models;
using LixTec.Platform.Business.Services.Models.Result;

namespace LixTec.Platform.Business.Service.Mapping;

public class TrashMapper
{
    public GetTrashByIdResult Map(Trash trash)
    {
        return new GetTrashByIdResult
        {
            Name = trash.Name,
            Street = trash.Street,
            Number = trash.Number
        };
    }

    /*     public GetTrashListResult Map(List<Trash> trashList)
        {
            return new GetTrashListResult
            {
                TrashList = trashList
            };
        } */
}
