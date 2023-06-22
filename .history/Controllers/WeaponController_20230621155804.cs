using dotnet_api.Dtos.Weapon;
using dotnet_api.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeaponController : ControllerBase
{
    private readonly IWeaponService weaponService;
    public WeaponController(IWeaponService weaponService)
    {
        this.weaponService = weaponService;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetCharaterDto>>> AddWeapon(AddWeaponDto newWeapon)
    {
        return Ok(await weaponService.AddWeapon())
    }
}