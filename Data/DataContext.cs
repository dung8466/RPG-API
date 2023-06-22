global using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "FireBall", Damage = 10 },
            new Skill { Id = 2, Name = "WaterWall", Damage = 20 },
            new Skill { Id = 3, Name = "EarthQuick", Damage = 15 }
        );
    }
    public DbSet<Charater> Charaters => Set<Charater>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Weapon> Weapons => Set<Weapon>();
    public DbSet<Skill> Skills => Set<Skill>();
}