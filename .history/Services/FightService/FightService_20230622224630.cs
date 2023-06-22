using dotnet_api.Dtos.Fight;

namespace dotnet_api.Services.FightService;

public class FightService : IFightService
{
    private readonly DataContext context;
    public FightService(DataContext context)
    {
        this.context = context;
    }

    public Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
    {
        throw new NotImplementedException();
    }
}