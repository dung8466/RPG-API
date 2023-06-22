namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    Task<ServiceResponse<List<Charater>>> GetAllCharaters();
    Task<ServiceResponse<Charater>> GetCharaterById(int id);
    Task<ServiceResponse<List<Charater>> AddCharater(Charater newCharater);
}