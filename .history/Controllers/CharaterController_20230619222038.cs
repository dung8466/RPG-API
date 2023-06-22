global using dotnet_api.Models;
global using dotnet_api.Services.CharaterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharaterController : ControllerBase
{
    public static List<Charater> charaters = new List<Charater>{
        new Charater(),
        new Charater{
            Id = 1,
            Name = "John"
        }
    };

    public CharaterController(ICharaterService charaterService)
    {

    }

    [HttpGet("GetAll")]
    public ActionResult<List<Charater>> GetAllCharaters()
    {
        return Ok(charaters);
    }

    [HttpGet("{id}")]
    public ActionResult<Charater> GetSingleCharater(int id)
    {
        return Ok(charaters.FirstOrDefault(c => c.Id == id));
    }

    [HttpPost]
    public ActionResult<List<Charater>> AddCharater(Charater newCharater)
    {
        charaters.Add(newCharater);
        return Ok(charaters);
    }
}