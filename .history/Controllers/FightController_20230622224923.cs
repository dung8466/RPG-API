using dotnet_api.Dtos.Fight;
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

    public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
    {
        return Ok(await fightService.WeaponAttack(request));
    }
}