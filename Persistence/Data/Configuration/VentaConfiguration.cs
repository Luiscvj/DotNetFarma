
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder.Property(x => x.FechaVenta)
               .HasColumnType("datetime")
               .IsRequired();
        
        builder.HasOne(a => a.Empleado)
               .WithMany(e => e.Ventas)
               .HasForeignKey(i => i.EmpleadoId)
               .IsRequired();

        builder.HasOne(a => a.Paciente)
               .WithMany(e => e.Ventas)
               .HasForeignKey(i => i.PacienteId)
               .IsRequired();
    }
}
