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
            var attacker = await context.Charaters
                .Include(c => c.Weapon)
                .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
            var opponent = await context.Charaters
                .FirstOrDefaultAsync(c => c.Id == request.OpponentId);
            if (attacker is null || opponent is null || attacker.Weapon is null)
            {
                throw new Exception("Something went wrong.");
            }
            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}