using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab8.Models.Entities
{
    public class APBDDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        public APBDDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultDoctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Adam",
                    LastName = "Małysz",
                    Email = "skoczny_doktor@narty.pl"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Grażyna",
                    LastName = "Tesco",
                    Email = "reklama@profesjonalna.com"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Maja",
                    LastName = "Ztaźgo",
                    Email = "niechjuzzamknietwarz@wp.pl"
                }
            };

            modelBuilder.Entity<Doctor>(e => {
                e.ToTable("Doctor");
                e.HasKey(e => e.IdDoctor);

                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Doctor>().HasData(defaultDoctors);

            var defaultPatients = new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Hanna",
                    LastName = "Tektura",
                    Birthdate = new System.DateTime(1971, 4, 27)
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Antoni",
                    LastName = "Dzwoni",
                    Birthdate = new System.DateTime(1960, 10, 14)
                },
                new Patient
                {
                    IdPatient = 3,
                    FirstName = "Halina",
                    LastName = "Malina",
                    Birthdate = new System.DateTime(1999, 8, 10)
                },

                new Patient
                {
                    IdPatient = 4,
                    FirstName = "Róża",
                    LastName = "Konfitura",
                    Birthdate = new System.DateTime(1999, 1, 1)
                }
            };

            modelBuilder.Entity<Patient>(e => {
                e.ToTable("Patient");
                e.HasKey(e => e.IdPatient);

                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Birthdate).IsRequired();
            });

            modelBuilder.Entity<Patient>().HasData(defaultPatients);

            var defaultPrescriptions = new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    IdPatient = 2,
                    IdDoctor = 3,
                    DueDate = new System.DateTime(2022, 6, 30),
                    Date = System.DateTime.Now
                },
                new Prescription
                {
                    IdPrescription = 2,
                    IdPatient = 1,
                    IdDoctor = 3,
                    DueDate = new System.DateTime(2020, 6, 30),
                    Date = new System.DateTime(2020, 4, 30)
                },
                new Prescription
                {
                    IdPrescription = 3,
                    IdPatient = 1,
                    IdDoctor = 2,
                    DueDate = new System.DateTime(2019, 1, 12),
                    Date = new System.DateTime(2019, 1, 30)
                },
                new Prescription
                {
                    IdPrescription = 4,
                    IdPatient = 3,
                    IdDoctor = 3,
                    DueDate = new System.DateTime(2020, 6, 30),
                    Date = new System.DateTime(2020, 4, 30)
                },
                new Prescription
                {
                    IdPrescription = 5,
                    IdPatient = 2,
                    IdDoctor = 1,
                    DueDate = new System.DateTime(2021, 11, 18),
                    Date = new System.DateTime(2020, 11, 3)
                },
                new Prescription
                {
                    IdPrescription = 6,
                    IdPatient = 4,
                    IdDoctor = 1,
                    DueDate = new System.DateTime(2020, 12, 1),
                    Date = new System.DateTime(2020, 11, 15)
                }
            };

            modelBuilder.Entity<Prescription>(e => {
                e.ToTable("Prescription");
                e.HasKey(e => e.IdPrescription);

                e.Property(e => e.Date).IsRequired();
                e.Property(e => e.DueDate).IsRequired();

                e.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient).OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Prescription>().HasData(defaultPrescriptions);

            var defaultMedicament = new List<Medicament>
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Nurofin",
                    Description = "Na ból głowy",
                    Type = "Tabletki"
                }, 
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Apas",
                    Description = "Na ból kolan",
                    Type = "Tabletki"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Avim",
                    Description = "Na ból gardła",
                    Type = "Syrop"
                },
                new Medicament
                {
                    IdMedicament = 4,
                    Name = "Acodin",
                    Description = "Na fazke i kaszelek",
                    Type = "Syrop"
                }
            };
            
            modelBuilder.Entity<Medicament>(e => {
                e.ToTable("Medicament");
                e.HasKey(e => e.IdMedicament);

                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(100).IsRequired();
                e.Property(e => e.Type).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Medicament>().HasData(defaultMedicament);

            var defaultPrescriptionMedicaments = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 2,
                    Details = "Pomoże zawsze"
                },
                 new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 2,
                    Dose = 3,
                    Details = ""
                }
            };

            modelBuilder.Entity<PrescriptionMedicament>(e => {
                e.ToTable("PrescriptionMedicament");
                e.HasKey(e => new {e.IdPrescription, e.IdMedicament});

                //e.Property(e => e.Dose).IsRequired();
                e.Property(e => e.Details).HasMaxLength(100).IsRequired();

                e.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription).OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(defaultPrescriptionMedicaments);
        }
    }
}