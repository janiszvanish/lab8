using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models.DTOs;
using lab8.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service){
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDoctorsAsync()
        {
            var doctors = await _service.GetAllDoctorsAsync();

            if(doctors is null)
                return NotFound("Nie ma lekarzy");

            
            return Ok(doctors);

        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorByIdAsync(int id)
        {
            var doc = await _service.GetDoctorByIdAsync(id);
            if(doc is null)
                return NotFound("Brak doktora o podanym id");
            
            return Ok(doc);
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var d = await _service.DeleteDoctorAsync(id);

            if(!d)
                return NotFound("Nie można usunąć doktora o takim id");
            
            return Ok("Doktor usunięty");
        }

        [HttpPut]
        public async Task<IActionResult> EditDoctor(int id, DoctorPut put)
        {
            var d = await _service.EditDoctorAsync(id, put);

            if(d)
                return Ok("Doktor edytowany");
            
            return NotFound("Nie można było edytować tego doktora");
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorPost post)
        {
            var d = await _service.AddDoctorAsync(post);
            if(d)
                return Ok("pomyślnie dodano doktora");
            return NotFound("Nie można było dodać doktora");
        }
    }
}