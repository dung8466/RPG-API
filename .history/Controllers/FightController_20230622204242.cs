using dotnet_api.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FightController : ControllerBase
{
    public FightController(IFightService fightService)
    {

    }
}