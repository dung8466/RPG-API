global using dotnet_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharaterController : ControllerBase
{
    public static Charater knight = new Charater();
    public IActionResult Get()
    {
        return Ok(knight);
    }
}