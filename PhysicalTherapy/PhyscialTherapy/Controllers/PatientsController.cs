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
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _context;

        public PatientsController(IPatientRepository context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatient()
        {
            return new ObjectResult(_context.GetAll());
        }

        // GET: api/Patients/tid/5
        [HttpGet("tid/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatientByTherapistId([FromRoute] int id)
        {
            return new ObjectResult(_context.GetByTherapistId(id));
        }

        //GET: api/Patients/new_routines
        [HttpGet("new_feedback/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatientsWithNewRoutines([FromRoute] int id)
        {
            return new ObjectResult(_context.GetByTherapistId(id));
        }

        //GET: api/Patients/new_routines
        [HttpGet("late_feedback/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetLatePatients([FromRoute] int id)
        {
            return new ObjectResult(_context.GetByTherapistId(id));
        }
    }
}