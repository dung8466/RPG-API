namespace dotnet_api.Data;

public class AuthRepository : IAuthRepository
{
    public DataContext Context { get; }
    public AuthRepository(DataContext context)
    {
        this.Context = context;

    }
    public Task<ServiceResponse<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<int>> Register(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExists(string username)
    {
        throw new NotImplementedException();
    }
}