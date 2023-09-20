using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class MedicamentoCompraConfiguration : IEntityTypeConfiguration<MedicamentoCompra>
    {
        public void Configure(EntityTypeBuilder<MedicamentoCompra> builder)
        {
            // Configure entity here
               builder.ToTable("table_name");

               builder.Property(x => x.PrecioCompra)
                       .HasPrecision(10,5);
               
               builder.HasOne(x => x.Medicamento)
                   .WithMany(x => x.MedicamentoCompras)
                   .HasForeignKey(x => x.MedicamentoId);

               builder.HasOne(x => x.Compra)
                   .WithMany(x => x.MedicamentoCompras)
                   .HasForeignKey(x => x.CompraId);
               builder.Property(x => x.PrecioCompra)
                    .HasPrecision(10,5);
                
                
               
               
        }
    }