using System.Security.Claims;
using dotnet_api.Dtos.Weapon;

namespace dotnet_api.Services.WeaponService;

public class WeaponService : IWeaponService
{
    private readonly DataContext context;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IMapper mapper;
    public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        this.context = context;

    }
    public async Task<ServiceResponse<GetCharaterDto>> AddWeapon(AddWeaponDto newWeapon)
    {
        var response = new ServiceResponse<GetCharaterDto>();
        try
        {
            var charater = await context.Charaters
                .FirstOrDefaultAsync(c => c.Id == newWeapon.CharaterId
                && c.User!.Id == int.Parse(httpContextAccessor.HttpContext!.User
                        .FindFirstValue(ClaimTypes.NameIdentifier)!));
            if (charater is null)
            {
                response.Success = false;
                response.Message = "Charater not found.";
                return response;
            }
            var weapon = new Weapon
            {
                Name = newWeapon.Name,
                Damage = newWeapon.Damage,
                Charater = charater
            };
            context.Weapons.Add(weapon);
            await context.SaveChangesAsync();
            response.Data =
        }
        catch (Exception ex)
        {

            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}