﻿using System;
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

        //public PatientsController(TherapistPatientContext context)
        //{
        //    _context = context;
        //}

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

        // GET: api/Patients/tid5
        [HttpGet("tid/{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public IActionResult GetPatientByTherapistId([FromRoute] int id)
        {
            return new ObjectResult(_context.GetByTherapistId(id));
        }

        [HttpGet("{id}")]
        [Produces(typeof(DbSet<Patient>))]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = await _context.FindById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPut("{id}")]
        [Produces(typeof(Patient))]
        public async Task<IActionResult> PutPatientId([FromRoute] int id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateTherapist(patient);
                return Ok(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }


        //GET: api/Patients/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPatient([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var patient = await _context.Patient.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(patient);
        //}

        // PUT: api/Patients/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPatient([FromRoute] int id, [FromBody] Patient patient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != patient.PatientId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(patient).State = EntityState.Modified;

        //    try
        //    {
        //        //await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Patients
        //[HttpPost]
        //public async Task<IActionResult> PostPatient([FromBody] Patient patient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //_context.Patient.Add(patient);
        //    //await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        //}

        // DELETE: api/Patients/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePatient([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var patient = await _context.Patient.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    //_context.Patient.Remove(patient);
        //    //await _context.SaveChangesAsync();

        //    return Ok(patient);
        //}

        //private bool PatientExists(int id)
        //{
        //    return _context.Patient.Any(e => e.PatientId == id);
        //}
    }
}