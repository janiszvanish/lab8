using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.DTOs;

namespace lab8.Services
{
    public interface IDoctorService
    {
        public Task<DoctorGet> CheckIfDoctorExistAsync(int id);

        public Task<DoctorGet> GetDoctorByIdAsync(int id);

        public Task<List<DoctorGet>> GetAllDoctorsAsync();

        public Task<bool> AddDoctorAsync(DoctorPost post);

        public Task<bool> DeleteDoctorAsync(int id);

        public Task<bool> EditDoctorAsync(int id, DoctorPut put);
    }
}