using Microsoft.EntityFrameworkCore;
using Zad10CodeFirst.Entities.Configs;
using Zad10CodeFirst.Entities.AppUserEntities;

namespace Zad10CodeFirst.Entities;

public class PrescriptionDbContext : DbContext
{
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public PrescriptionDbContext()
    {
    }

    public PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;User ID=sa;Password=Haslo123;Initial Catalog=MyDB;Integrated Security=False;Persist Security Info=False;Connect Timeout=30;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorEfConfiguration).Assembly);
    }
}