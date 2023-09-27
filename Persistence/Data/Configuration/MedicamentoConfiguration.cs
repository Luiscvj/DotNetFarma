
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");

        builder.Property(x => x.NombreMedicamento)
               .HasMaxLength(100)
               .IsRequired();
        
        builder.Property(x => x.Precio)
               .HasColumnType("double")
               .IsRequired();

        builder.Property(x => x.Stock)
               .HasColumnType("int")
               .IsRequired();

        builder.Property(x => x.FechaExpiracion)
               .HasColumnType("date")
               .IsRequired();
        
        builder.HasOne(a => a.Proveedor)
               .WithMany(e => e.Medicamentos)
               .HasForeignKey(i => i.ProveedorId)
               .IsRequired();  

       
              
    }
}
