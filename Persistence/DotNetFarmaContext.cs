using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataSeeding;

public class DotNetFarmaContext : DbContext
{
    public DotNetFarmaContext(DbContextOptions<DotNetFarmaContext> options) : base(options)
    {
    }

    DbSet<Proveedor> Proveedores {get;}
    DbSet<Paciente> Pacientes {get;}
    DbSet<Arl>Arls {get;}
    DbSet<Eps> Epss {get;}
    DbSet<Ciudad> Ciudades {get;}
    DbSet<Pais> Paises {get;}
    DbSet<Departamento> Departamentos {get;}
    DbSet<Rol> Roles {get;}
    DbSet<Cargo> Cargos {get;}
    DbSet<Compra> Compras {get;}
    DbSet<Empleado> Empleados {get;}
    DbSet<Medicamento> Medicamentos {get;}
    DbSet<Venta> Ventas {get;}
    DbSet<Usuario> Usuarios {get;}
    DbSet<RefreshToken> RefreshTokens {get;}

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