using dotnet_api.Dtos.Weapon;

namespace dotnet_api.Services.WeaponService;

public class WeaponService : IWeaponService
{
    private readonly DataContext context;
    private readonly IHttpContextAccessor httpContextAccessor;
    public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.context = context;

    }
    public Task<ServiceResponse<GetCharaterDto>> AddWeapon(AddWeaponDto newWeapon)
    {
        throw new NotImplementedException();
    }
}