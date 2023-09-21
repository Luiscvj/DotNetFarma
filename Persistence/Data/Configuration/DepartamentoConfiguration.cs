
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(x => x.Nombre)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasOne(a => a.Pais)
               .WithMany(e => e.Departamentos)
               .HasForeignKey(i => i.PaisId)
               .IsRequired();
    }
}
