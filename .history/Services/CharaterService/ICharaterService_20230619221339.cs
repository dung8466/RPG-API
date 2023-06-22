namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    List<Charater> GetAllCharaters();
    Charater GetCharaterById(int id);
    List<Charater> AddCharater(Charater charater);
}