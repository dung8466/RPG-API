using dotnet_api.Dtos.Fight;

namespace dotnet_api.Services.FightService;

public class FightService : IFightService
{
    private readonly DataContext context;
    public FightService(DataContext context)
    {
        this.context = context;
    }

    public async Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request)
    {
        var response = new ServiceResponse<FightResultDto>
        {
            Data = new FightResultDto()
        };
        try
        {
            var charaters = await context.Charaters
                .Include(c => c.Weapon)
                .Include(s => s.Skills)
                .Where(c => request.CharaterIds.Contains(c.Id)).ToListAsync();
            bool defeated = false;
            while (!defeated)
            {
                foreach (var attacker in charaters)
                {
                    var opponents = charaters.Where(c => c.Id != attacker.Id).ToList();
                    var opponent = opponents[new Random().Next(opponents.Count)];
                    int damage = 0;
                    string attackUsed = string.Empty;
                    bool useWeapon = new Random().Next(2) == 0;
                    if (useWeapon && attacker.Weapon is not null)
                    {
                        attackUsed = attacker.Weapon.Name;
                    }
                    else if (!useWeapon && attacker.Skills is not null) { }
                    else
                    {
                        response.Data.Log.Add($"{attacker.Name} can't attack.");
                        continue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
    {
        var response = new ServiceResponse<AttackResultDto>();
        try
        {
            var attacker = await context.Charaters
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
            var opponent = await context.Charaters
                .FirstOrDefaultAsync(c => c.Id == request.OpponentId);
            if (attacker is null || opponent is null || attacker.Skills is null)
            {
                throw new Exception("Something went wrong.");
            }
            var skill = attacker.Skills.FirstOrDefault(s => s.Id == request.SkillId);
            if (skill is null)
            {
                response.Success = false;
                response.Message = $"{attacker.Name} doesn't have that skill.";
                return response;
            }
            int damage = skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0)
            {
                opponent.HitPoints -= damage;
            }
            if (opponent.HitPoints <= 0)
            {
                response.Message = $"{opponent.Name} has been defeated!";
            }
            await context.SaveChangesAsync();
            response.Data = new AttackResultDto
            {
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
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
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0)
            {
                opponent.HitPoints -= damage;
            }
            if (opponent.HitPoints <= 0)
            {
                response.Message = $"{opponent.Name} has been defeated!";
            }
            await context.SaveChangesAsync();
            response.Data = new AttackResultDto
            {
                Attacker = attacker.Name,
                Opponent = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}