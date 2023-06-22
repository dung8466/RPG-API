using dotnet_api.Dtos.Fight;

namespace dotnet_api.Services.FightService;

public class FightService : IFightService
{
    private readonly DataContext context;
    public FightService(DataContext context)
    {
        this.context = context;
    }

    public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
    {
        var response = new ServiceResponse<AttackResultDto>();
        try
        {
            var attacker = await request
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}