namespace dotnet_api.Services.FightService;

public class FightService : IFightService
{
    private readonly DataContext context;
    public FightService(DataContext context)
    {
        this.context = context;
    }
}