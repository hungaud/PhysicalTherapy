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
            return new ObjectResult(_routineRepository.GetAll());
        }

        [HttpGet("{username:alpha}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetRoutines([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var credential = await _routineRepository.Get(username);

            if (credential == null)
                return NotFound();

            return Ok(credential);
        }


        [HttpGet("{id:int}")]
        [Produces(typeof(DbSet<Routine>))]
        public async Task<IActionResult> GetRoutines([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var credential = await _routineRepository.Get(id);

            if (credential == null)
                return NotFound();

            return Ok(credential);
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
