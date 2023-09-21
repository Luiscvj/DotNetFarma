using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class MedicamentoVentaConfiguration : IEntityTypeConfiguration<MedicamentoVenta>
    {
        public void Configure(EntityTypeBuilder<MedicamentoVenta> builder)
        {
            // Configure entity here
            builder.ToTable("medicamento_venta");

            builder.Property(x => x.CantidadVendida)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.PrecioVenta)
                   .HasPrecision(10,5)
                   .IsRequired();

            builder.HasOne(x => x.Venta)
                   .WithMany(x => x.MedicamentoVentas)
                   .HasForeignKey(x => x.VentaId);

            builder.HasOne(x => x.Medicamento)
                   .WithMany(x => x.MedicamentoVentas)
                   .HasForeignKey(x => x.MedicamentoId);
        }
    }