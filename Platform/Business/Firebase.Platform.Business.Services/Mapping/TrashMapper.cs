
using Firebase.Platform.Business.Entity.Models;
using Firebase.Platform.Business.Services.Models.Result;

namespace Firebase.Platform.Business.Service.Mapping;

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
}
