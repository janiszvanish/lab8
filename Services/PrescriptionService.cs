using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.DTOs;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab8.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly APBDDbContext _context;
        public PrescriptionService(APBDDbContext context){
            _context = context;
        }
        public async Task<PrescriptionGet> GetPrescription(int id)
        {
            var pr = await _context.Prescriptions.Where(e => e.IdPrescription == id).FirstOrDefaultAsync();
            if(pr is null)
                return null;
            
            var patient = await _context.Patients.Where(e => e.IdPatient == pr.IdPatient).FirstOrDefaultAsync();
            if(patient is null)
                return null;
            
            var doctor = await _context.Doctors.Where(e => e.IdDoctor == pr.IdDoctor).FirstOrDefaultAsync();
            if(doctor is null)
                return null;
            
            var m = await _context.PrescriptionMedicaments.Where(e => e.IdPrescription == id).ToListAsync();

            if(m is null)
                return null;
                
            List<MedicamentGet> meds = new List<MedicamentGet>();
            foreach(PrescriptionMedicament pm in m)
            {
                var medicament = await _context.Medicaments.Where(e => e.IdMedicament == pm.IdMedicament).FirstOrDefaultAsync();
                if(medicament is null)
                    continue;
                meds.Add(new MedicamentGet
                {
                    IdMedicament = medicament.IdMedicament,
                    Name = medicament.Name,
                    Type = medicament.Type,
                    Description = medicament.Description
                });
            }

            PrescriptionGet get = new PrescriptionGet
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                Doctor = doctor,
                Patient = patient,
                Medicaments = meds
            };

            return get;
            
        }
    }
}