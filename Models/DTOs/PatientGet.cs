using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Models
{
    public class PatientGet
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}