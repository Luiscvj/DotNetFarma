using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataSeeding;

public class DotNetFarmaContext : DbContext
{
    public DotNetFarmaContext(DbContextOptions<DotNetFarmaContext> options) : base(options)
    {
    }
    public DbSet<Arl> Arls {get;set;}
    public DbSet<Cargo> Cargos {get;set;}
    public DbSet<Ciudad> Ciudades {get;set;}
    public DbSet<Compra> Compras {get;set;}
    public DbSet<Departamento> Departamentos {get;set;}
    public DbSet<Empleado> Empleados {get;set;}
    public DbSet<Eps> Epss {get;set;}
    public DbSet<Medicamento> Medicamentos {get;set;}
    public DbSet<MedicamentoCompra> MedicamentoCompras {get;set;}
    public DbSet<MedicamentoVenta> MedicamentoVentas {get;set;}
    public DbSet<Paciente> Pacientes {get;set;}
    public DbSet<Pais> Paises {get;set;}
    public DbSet<Proveedor> Proveedores {get;set;}
    public DbSet<Rol> Roles {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Venta> Ventas {get;set;}
    public DbSet<UsuarioRoles> UsuarioRoles { get; set; }
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