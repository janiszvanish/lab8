using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.DTOs;
using lab8.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab8.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly APBDDbContext _context;
        public DoctorService(APBDDbContext context){
            _context = context;
        }

        public async Task<bool> AddDoctorAsync(DoctorPost post)
        {
            if(post is null)
                return false;
            else if(post.Email is null)
                return false;
            else if(post.FirstName is null)
                return false;
            else if(post.LastName is null)
                return false;

            Doctor doctor = new Doctor
            {
                FirstName = post.FirstName,
                LastName = post.LastName,
                Email = post.Email
            };

            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return true;
        }

        

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var d = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            if(d is null)
                return false;
            
            _context.Remove(d);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> EditDoctorAsync(int id, DoctorPut put)
        {
            var doctor = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            if(doctor is null)
                return false;

            if(!(put.Email is null))
                doctor.Email = put.Email;

            if(!(put.FirstName is null))
                doctor.FirstName = put.FirstName;
            
            if(!(put.LastName is null))
                doctor.LastName = put.LastName;

            
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<DoctorGet>> GetAllDoctorsAsync()
        {
            return await _context.Doctors
            .Select(e => new DoctorGet
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();
        }

        public async Task<DoctorGet> GetDoctorByIdAsync(int id)
        {
            var doctor = await CheckIfDoctorExistAsync(id);

            if(doctor is null)
                return null; 
            
            return doctor;
        }

        public async Task<DoctorGet> CheckIfDoctorExistAsync(int id)
        {
            var doctor = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            if(doctor is null)
                return null;
            
            DoctorGet doc = new DoctorGet
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };

            return doc;
        }
    }
}