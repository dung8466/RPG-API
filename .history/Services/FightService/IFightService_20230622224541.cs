using dotnet_api.Dtos.Fight;

namespace dotnet_api.Services.FightService;

public interface IFightService
{
    Task<ServiceResponse<AttackResultDto>> WeaponAttack()
}