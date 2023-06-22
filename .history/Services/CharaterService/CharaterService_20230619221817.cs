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
    public List<Charater> AddCharater(Charater newCharater)
    {
        charaters.Add(newCharater);
        return charaters;
    }

    public List<Charater> GetAllCharaters()
    {
        return charaters;
    }

    public Charater GetCharaterById(int id)
    {
        return charaters.FirstOrDefault(c => c.Id == id);
    }
}