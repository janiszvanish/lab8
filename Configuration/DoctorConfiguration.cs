using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab8.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(e => e.IdDoctor);

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            builder.HasData(
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
            );
        }
        
    }
}