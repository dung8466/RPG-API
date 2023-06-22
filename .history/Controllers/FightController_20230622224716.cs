using dotnet_api.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FightController : ControllerBase
{
    private readonly IFightService fightService;
    public FightController(IFightService fightService)
    {
        this.fightService = fightService;

    }

    public async Task<
}