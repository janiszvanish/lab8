using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.DTOs;
using lab8.Models.Entities;

namespace lab8.Services
{
    public interface IPrescriptionService
    {
        public Task<PrescriptionGet> GetPrescription(int id);
    }
}