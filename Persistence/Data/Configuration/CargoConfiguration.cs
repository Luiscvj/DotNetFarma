using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("Cargo");

        builder.Property(x => x.Nombre)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Descripcion)
               .HasMaxLength(50)
               .IsRequired();
    }
}