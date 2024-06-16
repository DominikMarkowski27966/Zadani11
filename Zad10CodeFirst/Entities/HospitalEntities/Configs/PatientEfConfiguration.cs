using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zad10CodeFirst.Entities.Configs;

public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasKey(e => e.IdPatient)
            .HasName("Pat_pk");

        builder
            .Property(e => e.IdPatient)
            .ValueGeneratedNever();

        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.BirthDay)
            .IsRequired();

        builder.ToTable("Patient");
    }
}