using dotnet_api.Dtos.Weapon;

namespace dotnet_api.Services.WeaponService;

public interface IWeaponService
{
    Task<ServiceResponse<GetCharaterDto>> AddWeapon(AddWeaponDto newWeapon);
}