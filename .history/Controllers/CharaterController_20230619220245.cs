global using dotnet_api.Models;
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
    public ActionResult<List<Charater>> AddCharater(Charater newCharater)
    {
        charaters.Add(newCharater);
        return Ok(charaters);
    }
}