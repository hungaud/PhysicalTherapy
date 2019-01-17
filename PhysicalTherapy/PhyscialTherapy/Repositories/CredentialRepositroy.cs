using PhysicalTherap.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhysicalTherap.Models;

namespace PhysicalTherapy.Repositories
{
    public interface ICredentialRepository
    {
        Task<Credential> Find(string username);
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
            return await _context.Credential.SingleOrDefaultAsync(cred => cred.Username == username);
        }
    }
}
