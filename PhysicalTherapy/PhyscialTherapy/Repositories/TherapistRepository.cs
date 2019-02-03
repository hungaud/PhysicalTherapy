using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Repositories
{
    public interface ITherapistRepository
    {
        Task<Therapist> Find(string username);

        IEnumerable<Therapist> GetAll();
    }

    public class TherapistRepository : ITherapistRepository
    {
        private PhysicalTherapyContext _context;

        public TherapistRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<Therapist> Find(string username)
        {
            return await _context.Therapists.Where(p => p.Username == username)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Therapist> GetAll()
        {
            return _context.Therapists;
        }
    }
}
