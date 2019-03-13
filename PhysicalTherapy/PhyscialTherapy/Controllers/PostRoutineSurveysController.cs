﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;

namespace PhysicalTherapy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostRoutineSurveysController : ControllerBase
    {
        private PhysicalTherapyContext _context;

        public PostRoutineSurveysController(PhysicalTherapyContext context)
        {
            _context = context;
        }

        // GET: api/PostRoutineSurveys
        [HttpGet]
        public IEnumerable<PostRoutineSurvey> GetPostRoutineSurveys()
        {
            return _context.PostRoutineSurveys;
        }

        // GET: api/PostRoutineSurveys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostRoutineSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postRoutineSurvey = await _context.PostRoutineSurveys.FindAsync(id);

            if (postRoutineSurvey == null)
            {
                return NotFound();
            }

            return Ok(postRoutineSurvey);
        }

        // PUT: api/PostRoutineSurveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostRoutineSurvey([FromRoute] int id, [FromBody] PostRoutineSurvey postRoutineSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postRoutineSurvey.PostRoutineSurveyId)
            {
                return BadRequest();
            }

            _context.Entry(postRoutineSurvey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostRoutineSurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PostRoutineSurveys
        [HttpPost]
        public async Task<IActionResult> PostPostRoutineSurvey([FromBody] PostRoutineSurvey postRoutineSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostRoutineSurveys.Add(postRoutineSurvey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostRoutineSurvey", new { id = postRoutineSurvey.PostRoutineSurveyId }, postRoutineSurvey);
        }

        // DELETE: api/PostRoutineSurveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostRoutineSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postRoutineSurvey = await _context.PostRoutineSurveys.FindAsync(id);
            if (postRoutineSurvey == null)
            {
                return NotFound();
            }

            _context.PostRoutineSurveys.Remove(postRoutineSurvey);
            await _context.SaveChangesAsync();

            return Ok(postRoutineSurvey);
        }

        private bool PostRoutineSurveyExists(int id)
        {
            return _context.PostRoutineSurveys.Any(e => e.PostRoutineSurveyId == id);
        }
    }
}