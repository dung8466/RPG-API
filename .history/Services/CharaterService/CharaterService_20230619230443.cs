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
    public async Task<ServiceResponse<List<GetCharaterDto>>> AddCharater(AddCharaterDto newCharater)
    {
        var serviceResponse = new ServiceResponse<List<Charater>>();
        charaters.Add(newCharater);
        serviceResponse.Data = charaters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharaters()
    {
        var serviceResponse = new ServiceResponse<List<Charater>>();
        serviceResponse.Data = charaters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> GetCharaterById(int id)
    {
        var serviceResponse = new ServiceResponse<Charater>();
        var charater = charaters.FirstOrDefault(c => c.Id == id);
        serviceResponse.Data = charater;
        return serviceResponse;
    }
}