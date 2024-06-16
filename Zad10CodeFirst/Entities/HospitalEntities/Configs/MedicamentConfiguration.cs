using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zad10CodeFirst.Entities.Configs;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>

{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder
            .HasKey(x => x.IdMedicament)
            .HasName("Med_pk");

        builder
            .Property(e => e.IdMedicament)
            .ValueGeneratedNever();

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .ToTable("Medicament");
    }
}