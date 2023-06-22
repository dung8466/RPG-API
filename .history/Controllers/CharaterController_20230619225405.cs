global using dotnet_api.Models;
global using dotnet_api.Services.CharaterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharaterController : ControllerBase
{

    private readonly ICharaterService charaterService;

    public CharaterController(ICharaterService charaterService)
    {
        this.charaterService = charaterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<Charater>>>> GetAllCharaters()
    {
        return Ok(await charaterService.GetAllCharaters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Charater>>> GetSingleCharater(int id)
    {
        return Ok(await charaterService.GetCharaterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Charater>>>> AddCharater(Charater newCharater)
    {
        return Ok(await charaterService.AddCharater(newCharater));
    }
}