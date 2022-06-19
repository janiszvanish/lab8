using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.Entities;

namespace lab8.Models.DTOs
{
    public class PrescriptionGet
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public List<MedicamentGet> Medicaments { get; set; }



    }
}