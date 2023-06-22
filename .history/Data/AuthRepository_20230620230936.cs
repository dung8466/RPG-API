using System.Security.Claims;

namespace dotnet_api.Data;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext context;
    private readonly IConfiguration configuration;
    public AuthRepository(DataContext context, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.context = context;

    }
    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));
        if (user is null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password.";
        }
        else
        {
            response.Data = CreateToken(user);
        }
        return response;
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        var response = new ServiceResponse<int>();
        if (await UserExists(user.UserName))
        {
            response.Success = false;
            response.Message = "User already exists.";
            return response;
        }
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        context.Users.Add(user);
        await context.SaveChangesAsync();

        response.Data = user.Id;
        return response;
    }

    public async Task<bool> UserExists(string username)
    {
        if (await context.Users.AnyAsync(u => u.UserName.ToLower() == username.ToLower()))
        {
            return true;
        }
        return false;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
    private string CreateToken(User user)
    {
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };
        var appSettingsToken = configuration.GetSection("Appsettings:Token").Value;
        return string.Empty;
    }
}