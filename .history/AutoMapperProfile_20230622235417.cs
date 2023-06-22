using dotnet_api.Dtos.Skill;
using dotnet_api.Dtos.Weapon;

namespace dotnet_api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Charater, GetCharaterDto>();
        CreateMap<AddCharaterDto, Charater>();
        CreateMap<UpdateCharaterDto, Charater>();
        CreateMap<Weapon, GetWeaponDto>();
        CreateMap<Skill, GetSkillDto>();
        CreateMap<CharaterH, GetSkillDto>();
    }
}