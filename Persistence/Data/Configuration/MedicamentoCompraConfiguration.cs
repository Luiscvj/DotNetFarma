using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class MedicamentoCompraConfiguration : IEntityTypeConfiguration<MedicamentoCompra>
    {
        public void Configure(EntityTypeBuilder<MedicamentoCompra> builder)
        {
            // Configure entity here
            builder.ToTable("medicamento_compra");

            builder.Property(x => x.CantidadComprada)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.PrecioCompra)
                   .HasPrecision(10,5)
                   .IsRequired();
            
            builder.HasOne(x => x.Medicamento)
                   .WithMany(x => x.MedicamentoCompras)
                   .HasForeignKey(x => x.MedicamentoId);

            builder.HasOne(x => x.Compra)
                   .WithMany(x => x.MedicamentoCompras)
                   .HasForeignKey(x => x.CompraId);     
        }
    }