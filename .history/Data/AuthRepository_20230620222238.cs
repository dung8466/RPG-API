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
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        context.Users.Add(user);
        await context.SaveChangesAsync();
        var response = new ServiceResponse<int>();
        response.Data = user.Id;
        return response;
    }

    public async Task<bool> UserExists(string username)
    {
        if (await context.Users.AnyAsync(u => u.UserName))
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}