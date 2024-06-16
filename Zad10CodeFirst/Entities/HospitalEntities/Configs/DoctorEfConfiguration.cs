using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zad10CodeFirst.Entities.Configs;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .HasKey(e => e.IdDoctor)
            .HasName("Doc_pk");

        builder
            .Property(x => x.IdDoctor)
            .ValueGeneratedNever();

        builder
            .Property(x => x.FirstName)
            .ValueGeneratedNever();

        builder
            .Property(x => x.LastName)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .IsRequired();

        builder.ToTable("Doctor");
    }
}