using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhysicalTherapy.Models;
using PhysicalTherapy.Repositories;

namespace PhysicalTherapy.Controllers
{
    [Produces("application/json")]
    [Route("api/Credential")]
    public class CredentialController: Controller 
    {
        private readonly ICredentialRepository _credentialRepository;

        public CredentialController(ICredentialRepository credentailRepository) {
            _credentialRepository = credentailRepository;
        }

        [HttpGet]
        [Produces(typeof(Credential))]
        public async Task<IActionResult> GetCredential([FromBody] string username) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            const credential = await _credentialRepository.Find(username);

            if (customer == null)
            {
                return NotFound();
            }
            return ok(credential);
        }
    }
}
