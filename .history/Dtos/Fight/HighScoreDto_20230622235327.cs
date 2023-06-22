namespace dotnet_api.Dtos.Fight;

public class HighScoreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Fights { get; set; }
}