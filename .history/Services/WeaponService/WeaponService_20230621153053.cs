using dotnet_api.Dtos.Weapon;

namespace dotnet_api.Services.WeaponService;

public class WeaponService : IWeaponService
{
    public Task<ServiceResponse<GetCharaterDto>> AddWeapon(AddWeaponDto newWeapon)
    {
        throw new NotImplementedException();
    }
}