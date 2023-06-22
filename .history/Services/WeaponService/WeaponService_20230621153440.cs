using dotnet_api.Dtos.Weapon;

namespace dotnet_api.Services.WeaponService;

public class WeaponService : IWeaponService
{
    private readonly DataContext context;
    public WeaponService(DataContext context)
    {
        this.context = context;

    }
    public Task<ServiceResponse<GetCharaterDto>> AddWeapon(AddWeaponDto newWeapon)
    {
        throw new NotImplementedException();
    }
}