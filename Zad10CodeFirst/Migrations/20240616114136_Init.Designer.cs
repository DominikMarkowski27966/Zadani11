﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zad10CodeFirst.Entities;

#nullable disable

namespace Zad10CodeFirst.Migrations
{
    [DbContext(typeof(PrescriptionDbContext))]
    [Migration("20240616114136_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Zad10CodeFirst.Entities.AppUserEntities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser")
                        .HasName("AU_pk");

                    b.ToTable("AppUser", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDoctor")
                        .HasName("Doc_pk");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("Med_pk");

                    b.ToTable("Medicament", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatient")
                        .HasName("Pat_pk");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorIdDoctor")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<int>("PatientIdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Pre_pk");

                    b.HasIndex("DoctorIdDoctor");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.HasIndex("PatientIdPatient");

                    b.ToTable("Prescription", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentIdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("PrescriptionIdPrescription")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament")
                        .HasName("PreMed_pk");

                    b.HasIndex("IdMedicament");

                    b.HasIndex("MedicamentIdMedicament");

                    b.HasIndex("PrescriptionIdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Prescription", b =>
                {
                    b.HasOne("Zad10CodeFirst.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorIdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zad10CodeFirst.Entities.Doctor", null)
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Prescription_Doctor");

                    b.HasOne("Zad10CodeFirst.Entities.Patient", null)
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Prescription_Patient");

                    b.HasOne("Zad10CodeFirst.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientIdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.PrescriptionMedicament", b =>
                {
                    b.HasOne("Zad10CodeFirst.Entities.Medicament", null)
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicamen_Medicament");

                    b.HasOne("Zad10CodeFirst.Entities.Prescription", null)
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicament_Prescriptions");

                    b.HasOne("Zad10CodeFirst.Entities.Medicament", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentIdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zad10CodeFirst.Entities.Prescription", "Prescription")
                        .WithMany()
                        .HasForeignKey("PrescriptionIdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Zad10CodeFirst.Entities.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
