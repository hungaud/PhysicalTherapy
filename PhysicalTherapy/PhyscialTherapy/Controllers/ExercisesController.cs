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
    [Route("api/exercises")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exercises;

        public ExercisesController(IExerciseRepository context)
        {
            _exercises = context;
        }

        // GET: api/Exercises
        [HttpGet]
        [Produces(typeof(DbSet<Exercise>))]
        public IActionResult GetExcercises()
        {
            return new ObjectResult(_exercises.GetAll());
        }

        //// GET: api/Exercises/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetExercise([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var exercise = await _exercises.Excercises.FindAsync(id);

        //    if (exercise == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(exercise);
        //}

        //// PUT: api/Exercises/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutExercise([FromRoute] int id, [FromBody] Exercise exercise)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != exercise.ExerciseId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(exercise).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ExerciseExists(id))
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

        [HttpPost]
        [Produces(typeof(Exercise))]
        public async Task<IActionResult> PostOrder([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //try
            //{
                await _exercises.Add(exercise);
            //}
            //catch (DbUpdateException)
            //{
            //    if (!await OrderExists(exercise.ExerciseId))
            //        return NotFound();
            //    else
            //        return BadRequest();
            //}

            return CreatedAtAction("GetOrder", new { id = exercise.ExerciseId }, exercise);
        }

        //// DELETE: api/Exercises/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var exercise = await _context.Excercises.FindAsync(id);
        //    if (exercise == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Excercises.Remove(exercise);
        //    await _context.SaveChangesAsync();

        //    return Ok(exercise);
        //}

        //private bool ExerciseExists(int id)
        //{
        //    return _context.Excercises.Any(e => e.ExerciseId == id);
        //}
    }
}