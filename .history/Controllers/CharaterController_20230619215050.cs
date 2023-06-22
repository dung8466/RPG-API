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
            Name = "John"
        }
    };

    [HttpGet("GetAll")]
    public ActionResult<List<Charater>> GetAllCharaters()
    {
        return Ok(charaters);
    }
    [HttpGet]
    public ActionResult<Charater> GetSingleCharater()
    {
        return Ok(charaters[0]);
    }
}