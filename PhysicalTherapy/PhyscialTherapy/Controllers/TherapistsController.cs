using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using PhysicalTherapy.Repositories;

namespace PhysicalTherapy.Controllers
{
    [Produces("application/json")]
    [Route("api/therapists")]
    public class TherapistsController : Controller
    {
        private readonly ITherapistRepository _therapists;

        public TherapistsController(ITherapistRepository context)
        {
            _therapists = context;
        }

        // GET: api/Therapists/username
        [HttpGet("{username:alpha}")]
        [Produces(typeof(DbSet<Therapist>))]
        public async Task<IActionResult> GetTherapist([FromRoute] string username)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var therapist = await _therapists.Find(username);

            if (therapist == null)
                return NotFound();

            return Ok(therapist);
        }

        // GET: api/therapists
        [HttpGet]
        [Produces(typeof(DbSet<Therapist>))]
        public IActionResult GetPatient()
        {
            var test = new ObjectResult(_therapists.GetAll());
            return test;
        }
    }
}
