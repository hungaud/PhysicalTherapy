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
    [Route("api/RoutineExercises")]
    public class RoutineExerciseController : ControllerBase
    {
        private readonly IRoutineExerciseRepository _routineExerciseRepository;

        public RoutineExerciseController(IRoutineExerciseRepository routineExerciseRepository)
        {
            _routineExerciseRepository = routineExerciseRepository;
        }

        [HttpGet]
        [Produces(typeof(DbSet<RoutineExercise>))]
        public IActionResult GetRoutineExercises()
        {
            var test = new ObjectResult(_routineExerciseRepository.GetAll());
            return test;
        }

        // POST: api/RoutineExercises
        [HttpPost]
        [Produces(typeof(DbSet<RoutineExercise>))]
        public async Task<IActionResult> PostRoutineExercise([FromBody] RoutineExercise routineExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _routineExerciseRepository.Add(routineExercise);

            return CreatedAtAction("GetRoutineExercises", new { id = routineExercise.RoutineId }, routineExercise);
        }
    }
}
