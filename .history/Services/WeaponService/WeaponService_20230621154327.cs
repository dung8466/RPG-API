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

        }
        catch (Exception ex)
        {

            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}