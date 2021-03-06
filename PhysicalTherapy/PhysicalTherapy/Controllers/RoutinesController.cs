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
    [Route("api/Routines")]
    public class RoutinesController : ControllerBase
    {
        private readonly IRoutineRepository _routineRepository;

        public RoutinesController(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }


        [HttpGet]
        [Produces(typeof(DbSet<Routine>))]
        public IActionResult GetRoutines()
        {
            var test = new ObjectResult(_routineRepository.GetAll());
            return test;
        }

        [HttpGet("{username:alpha}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetRoutines([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = await _routineRepository.Get(username);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }


        [HttpGet("{id:int}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetRoutines([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = await _routineRepository.Get(id);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }

        [HttpGet("recent_feedback/{id:int}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetRecentRoutineCompletionsWithFeedback([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = await _routineRepository.GetRecentRoutineCompletionsWithFeedback(id);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }

        [HttpGet("late_patients/{id:int}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetLateRoutinesByTherapistId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = await _routineRepository.GetLateRoutinesByTherapistId(id);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }

        [HttpGet("routine_id/{id:int}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetFullRoutineByRoutineId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var routine = await _routineRepository.GetFullRoutineByRoutineId(id);

            if (routine == null)
                return NotFound();

            return Ok(routine);
        }

        // POST: api/routines
        [HttpPost]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> PostRoutine([FromBody] Routine routine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _routineRepository.Add(routine);

            return CreatedAtAction("GetRoutines", new { id = routine.RoutineId }, routine);
        }
    }
}


// test method
//[HttpGet("Routines2/{id}")]
//[Produces(typeof(DbSet<Credential>))]
//public async Task<IActionResult> GetRoutines2([FromRoute] int id)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    var credential = await _routineRepository.TestGet(id);

//    if (credential == null)
//    {
//        return NotFound();
//    }
//    return Ok(credential);
//}
