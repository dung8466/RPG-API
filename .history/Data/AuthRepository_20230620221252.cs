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
        await context.SaveChangesAsync();
        var response = new ServiceResponse<int>();
        response.Data = user.Id;
        return response;
    }

    public Task<bool> UserExists(string username)
    {
        throw new NotImplementedException();
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA256)
    }
}