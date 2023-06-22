namespace dotnet_api.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public Charater? Charater { get; set; }
}