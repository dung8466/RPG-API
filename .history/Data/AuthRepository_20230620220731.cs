namespace dotnet_api.Data;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext context;
    public AuthRepository(DataContext context)
    {
        this.context = context;

    }
    public Task<ServiceResponse<string>> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        context.Users.Add(user);
        await
    }

    public Task<bool> UserExists(string username)
    {
        throw new NotImplementedException();
    }
}