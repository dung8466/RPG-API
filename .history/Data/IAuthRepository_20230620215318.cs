namespace dotnet_api.Data;

public interface IAuthRepository
{
    Task<ServiceResponse<int>> Register
}