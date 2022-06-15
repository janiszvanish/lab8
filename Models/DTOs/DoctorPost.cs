using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Models.DTOs
{
    public class DoctorPost
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
    }
}