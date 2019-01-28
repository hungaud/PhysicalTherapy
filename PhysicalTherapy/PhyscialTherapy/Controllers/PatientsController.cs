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
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patients;

        public PatientsController(IPatientRepository context)
        {
            _patients = context;
        }

        // GET: api/Patients
        [HttpGet]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatient()
        {
            var test = new ObjectResult(_patients.GetAll());
            return test;
        }

        // GET: api/Patients/username
        [HttpGet("{username:alpha}")]
        [Produces(typeof(DbSet<Patient>))]
        public async Task<IActionResult> GetPatient([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = await _patients.Find(username);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }


        // GET: api/Patients/tid/5
        [HttpGet("tid/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatientByTherapistId([FromRoute] int id)
        {
            return new ObjectResult(_patients.GetByTherapistId(id));
        }

        //GET: api/Patients/new_routines
        [HttpGet("new_feedback/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatientsWithNewRoutines([FromRoute] int id)
        {
            return new ObjectResult(_patients.GetByTherapistId(id));
        }

        //GET: api/Patients/new_routines
        [HttpGet("late_feedback/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetLatePatients([FromRoute] int id)
        {
            return new ObjectResult(_patients.GetByTherapistId(id));
        }
    }
}