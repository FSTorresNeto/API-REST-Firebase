using Firebase.Api.Application.Models.Response;

namespace Firebase.Api.Application.Mapping;

public class ResponseMapper
{
    public static Response Map(bool success, dynamic data = null, string message = null)
    {
        return new Response
        {
            Success = success,
            Data = data,
            Message = message
        };
    }


    public static Response Map(dynamic data = null)
    {
        return new Response
        {
            Data = data,
        };
    }
}
