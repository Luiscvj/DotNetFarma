using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DotNetFarmaContext : DbContext
{
    public DotNetFarmaContext(DbContextOptions<DotNetFarmaContext> options) : base(options)
    {
    }

    DbSet<Proveedor> Proveedores {get;}
    DbSet<Paciente> Pacientes {get;}
    DbSet<Usuario> Usuarios {get;}

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
    }
}