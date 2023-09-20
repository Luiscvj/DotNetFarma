using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");

        builder.Property(x => x.FechaCompra)
               .HasColumnType("date")
               .IsRequired();

        builder.Property(x => x.Cantidad)
               .HasColumnType("int")
               .IsRequired();

        builder.Property(x => x.Precio)
               .HasColumnType("int")
               .IsRequired();

        builder.HasOne(a => a.Proveedor)
               .WithMany(e => e.Compras)
               .HasForeignKey(i => i.ProveedorId)
               .IsRequired();

    }
}