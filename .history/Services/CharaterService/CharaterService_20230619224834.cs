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
    public async Task<ServiceResponse<List<Charater>>> AddCharater(Charater newCharater)
    {
        var serviceResponse = new ServiceResponse<
        charaters.Add(newCharater);
        return charaters;
    }

    public async Task<ServiceResponse<List<Charater>>> GetAllCharaters()
    {
        return charaters;
    }

    public async Task<ServiceResponse<Charater>> GetCharaterById(int id)
    {
        var charater = charaters.FirstOrDefault(c => c.Id == id);
        if (charater is not null)
        {
            return charater;
        }
        throw new Exception("Charater not found");
    }
}