global using AutoMapper;

namespace dotnet_api.Services.CharaterService;

public class CharaterService : ICharaterService
{
    public static List<Charater> charaters = new List<Charater>{
        new Charater(),
        new Charater{
            Id = 1,
            Name = "John"
        }
    };
    private readonly IMapper mapper;

    public CharaterService(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetCharaterDto>>> AddCharater(AddCharaterDto newCharater)
    {
        var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
        var charater = mapper.Map<Charater>(newCharater);
        charater.Id = charaters.Max(c => c.Id) + 1;
        charaters.Add(charater);
        serviceResponse.Data = charaters.Select(c => mapper.Map<GetCharaterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharaters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
        serviceResponse.Data = charaters.Select(c => mapper.Map<GetCharaterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> GetCharaterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharaterDto>();
        var charater = charaters.FirstOrDefault(c => c.Id == id);
        serviceResponse.Data = mapper.Map<GetCharaterDto>(charater);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> UpdateCharater(UpdateCharaterDto updateCharater)
    {
        var serviceResponse = new ServiceResponse<GetCharaterDto>();
        try
        {
            var charater = charaters.FirstOrDefault(c => c.Id == updateCharater.Id);
            charater.Name = updateCharater.Name;
            charater.HitPoints = updateCharater.HitPoints;
            charater.Strength = updateCharater.Strength;
            charater.Defense = updateCharater.Defense;
            charater.Intelligence = updateCharater.Intelligence;
            charater.Class = updateCharater.Class;
            serviceResponse.Data = mapper.Map<GetCharaterDto>(charater);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ""
        }
        return serviceResponse;
    }
}