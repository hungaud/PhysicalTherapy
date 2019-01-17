using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhysicalTherapy.Models;
using PhysicalTherapy.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace PhysicalTherapy.Controllers
{
    [Produces("application/json")]
    [Route("api/Credentials")]
    public class CredentialsController: Controller 
    {
        private readonly ICredentialRepository _credentialRepository;

        public CredentialsController(ICredentialRepository credentialRepository) {
            _credentialRepository = credentialRepository;
        }

        /*[HttpGet]
        [Produces(typeof(DbSet<Credential>))]
        public async Task<IActionResult> GetCredential([FromBody] string username) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var credential = await _credentialRepository.Find(username);

            if (credential == null)
            {
                return NotFound();
            }
            return Ok(credential);
        }*/

        [HttpGet]
        [Produces(typeof(DbSet<Credential>))]
        public IActionResult GetCredentials()
        {
            return new ObjectResult(_credentialRepository.GetAll());
        }
    }
}
