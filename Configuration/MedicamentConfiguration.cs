using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab8.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.ToTable("Medicament");
            builder.HasKey(e => e.IdMedicament);

            builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(100).IsRequired();

            builder.HasData(
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
            );

        }
        
    }
}