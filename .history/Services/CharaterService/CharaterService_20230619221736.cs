namespace dotnet_api.Services.CharaterService;

public class CharaterService : ICharaterService
{
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