using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab8.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(e => e.IdPatient);

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Birthdate).IsRequired();

            builder.HasData(
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
            );
        }
        
    }
}