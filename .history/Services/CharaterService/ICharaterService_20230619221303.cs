namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    List<Charater> GetAllCharaters();
    Charater GetCharaterById()
}