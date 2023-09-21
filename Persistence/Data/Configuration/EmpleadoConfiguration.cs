using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");

        builder.Property(x => x.Nombres)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Apellidos)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(x => x.Direccion)
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(x => x.Telefono)
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(x => x.FechaContratacion)
        .HasColumnType("date")
        .IsRequired();                                  

        builder.HasOne(a => a.Cargo)
               .WithMany(e => e.Empleados)
               .HasForeignKey(i => i.CargoId)
               .IsRequired();
        
        builder.HasOne(a => a.Ciudad)
               .WithMany(e => e.Empleados)
               .HasForeignKey(i => i.CiudadId)
               .IsRequired();
        
        builder.HasOne(a => a.Eps)
               .WithMany(e => e.Empleados)
               .HasForeignKey(i => i.EpsId)
               .IsRequired();

        builder.HasOne(a => a.Arl)
               .WithMany(e => e.Empleados)
               .HasForeignKey(i => i.ArlId)
               .IsRequired();

      
      
              
    }
}