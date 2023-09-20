using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataSeeding;

public class DotNetFarmaContext : DbContext
{
    public DotNetFarmaContext(DbContextOptions<DotNetFarmaContext> options) : base(options)
    {
    }

    public DbSet<Proveedor> Proveedores {get;}
    public DbSet<Paciente> Pacientes {get;}
    public DbSet<Arl>Arls {get;}
    public DbSet<Eps> Epss {get;}
    public DbSet<Ciudad> Ciudades {get;}
    public DbSet<Pais> Paises {get;}
    public DbSet<Departamento> Departamentos {get;}
    public DbSet<Rol> Roles {get;}
    public DbSet<Cargo> Cargos {get;}
    public DbSet<Compra> Compras {get;}
    public DbSet<Empleado> Empleados {get;}
    public DbSet<Medicamento> Medicamentos {get;}
    public DbSet<Venta> Ventas {get;}
    public DbSet<Usuario> Usuarios {get;}
    public DbSet<RefreshToken> RefreshTokens {get;}

    DbSet<Arl> Arls {get;}
    DbSet<Cargo> Cargos {get;}
    DbSet<Ciudad> Ciudades {get;}
    DbSet<Compra> Compras {get;}
    DbSet<Departamento> Departamentos {get;}
    DbSet<Empleado> Empleados {get;}
    DbSet<Eps> Eps {get;}
    

    protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
    {
        modelBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInitial.Seed(modelBuilder);
    }
}