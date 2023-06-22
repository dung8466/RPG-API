namespace dotnet_api.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[0];
}