using PhysicalTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Repositories
{

    public interface IPatientRepository
    {
        Task<Patient> Add(Patient patient);
        Task<bool> Exists(string username);
        Task<Patient> Get(string username);
        Task<Patient> Get(int id);
        IEnumerable<Patient> GetAll();
        Task<Patient> Remove(int id);
        Task<Patient> Update(string username);
    }

    public class PatientRepository : IPatientRepository
    {

        private PhysicalTherapyContext _context;

        public PatientRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }
        
        public Task<Patient> Add(Patient patient)
        {
            return null;
        }

        public Task<bool> Exists(string username)
        {
            return null;
        }

        public Task<Patient> Get(string username)
        {
            return null;
        }

        public Task<Patient> Get(int id)
        {
            return null;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients;
        }

        public Task<Patient> Remove(int id)
        {
            return null;
        }

        public Task<Patient> Update(string username)
        {
            return null;
        }
    }
}
