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
    public async Task<ActionResult<List<Charater>>> GetAllCharaters()
    {
        return Ok(charaterService.GetAllCharaters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Charater>> GetSingleCharater(int id)
    {
        return Ok(charaterService.GetCharaterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<List<Charater>>> AddCharater(Charater newCharater)
    {
        return Ok(charaterService.AddCharater(newCharater));
    }
}