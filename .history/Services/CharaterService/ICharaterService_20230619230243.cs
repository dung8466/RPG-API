using dotnet_api.Dtos.Charater;

namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharaters();
    Task<ServiceResponse<GetCharaterDto>> GetCharaterById(int id);
    Task<ServiceResponse<List<AddCharaterDto>>> AddCharater(Charater newCharater);
}