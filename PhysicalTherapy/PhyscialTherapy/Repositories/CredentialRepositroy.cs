using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhysicalTherapy.Models;
using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Controllers;

namespace PhysicalTherapy.Repositories
{
    public interface ICredentialRepository
    {
        Task<Credential> Find(string username);

        IEnumerable<Credential> GetAll();
    }

    public class CredentialRepository : ICredentialRepository
    {
        private PhysicalTherapyContext _context;

        public CredentialRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<Credential> Find(string username)
        {
            return await _context.Credentials.SingleOrDefaultAsync(cred => cred.Username == username);
        }

        public IEnumerable<Credential> GetAll()
        {
            return _context.Credentials;
        }
    }
}
