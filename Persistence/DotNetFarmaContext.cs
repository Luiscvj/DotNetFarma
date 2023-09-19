using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class DotNetFarmaContext : DbContext
{
    public DotNetFarmaContext(DbContextOptions<DotNetFarmaContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
    {
        modelBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}