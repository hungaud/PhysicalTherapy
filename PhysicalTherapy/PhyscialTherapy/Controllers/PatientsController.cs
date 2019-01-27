using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using PhysicalTherapy.Repositories;

namespace PhysicalTherapy.Controllers
{
    [Produces("application/json")]
    [Route("api/Patients")]
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patients;

        public PatientsController(IPatientRepository patient)
        {
            _patients = patient;
        }

        [HttpGet]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatients()
        {
            return new ObjectResult(_patients.GetAll());
        }

        [HttpGet("{username:alpha}")]
        [Produces(typeof(DbSet<Patient>))]
        public async Task<IActionResult> GetPatient([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = await _patients.Get(username);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
    }
}