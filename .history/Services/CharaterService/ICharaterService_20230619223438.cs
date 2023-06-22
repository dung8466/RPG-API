namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    Task<List<Charater>> GetAllCharaters();
    Task<Charater> GetCharaterById(int id);
    Task<List<Charater>> AddCharater(Charater newCharater);
}