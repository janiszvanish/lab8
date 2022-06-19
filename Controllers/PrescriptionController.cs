using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionController(IPrescriptionService service){
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrescriptionData(int id)
        {
            var p = await _service.GetPrescription(id);
            if(p is null)
                return NotFound("Nie znaleziono recepty");
            
            return Ok(p);
        }
    }
}