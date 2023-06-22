global using dotnet_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharaterController : ControllerBase
{
    public static List<Charater> charaters = new List<Charater>();

    [HttpGet]
    public ActionResult<Charater> Get()
    {
        return Ok(charaters);
    }
}