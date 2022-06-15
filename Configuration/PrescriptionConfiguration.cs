using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab8.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");
            builder.HasKey(e => e.IdPrescription);

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData(
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
            );
        
    }
}