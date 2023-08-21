using Microsoft.AspNetCore.Mvc;
using LixTec.Api.Application.Mapping;
using Microsoft.AspNetCore.Authorization;
using LixTec.Api.Application.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using LixTec.Platform.Business.Services.Models.Result;
using LixTec.Platform.Business.Factory.Service.Interfaces;

namespace LixTec.API.Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TrashController : ControllerBase
{
    private readonly ITrashServiceFactory _trashServiceFactory;

    public TrashController(ITrashServiceFactory trashServiceFactory)
    {
        _trashServiceFactory = trashServiceFactory;
    }

    [HttpGet()]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetAll()
    {
        List<GetTrashListResult> result = await _trashServiceFactory.Create().GetAllAsync();

        Response response = ResponseMapper.Map(result);

        return Ok(response);
    }
}
