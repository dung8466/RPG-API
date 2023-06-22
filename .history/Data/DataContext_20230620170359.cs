global using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Charater> Charaters => Set<Charater>();
    public DbSet<Charater> Charaters => Set<Charater>();
}