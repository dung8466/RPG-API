global using dotnet_api.Dtos.Charater;

namespace dotnet_api.Services.CharaterService;

public interface ICharaterService
{
    Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharaters(int userId);
    Task<ServiceResponse<GetCharaterDto>> GetCharaterById(int id);
    Task<ServiceResponse<List<GetCharaterDto>>> AddCharater(AddCharaterDto newCharater);
    Task<ServiceResponse<GetCharaterDto>> UpdateCharater(UpdateCharaterDto updateCharater);
    Task<ServiceResponse<List<GetCharaterDto>>> DeleteCharater(int id);
}