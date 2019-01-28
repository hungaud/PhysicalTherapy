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
    public interface IPatientRepository
    {
        Task<Patient> Find(string username);

        IEnumerable<Patient> GetAll();

        //Returns all patients associated with therapist ID
        IEnumerable<Patient> GetByTherapistId(int id);

        Task<Patient> UpdateTherapist(Patient patient);

        Task<Patient> FindById(int id);
        //Returns all patients associated with therapist ID where Routine.isNew == true
        IEnumerable<Patient> GetPatientsWithNewFeedbackByTherapistId(int id);

        //Returns all patients who don't have a new routine
        IEnumerable<Patient> GetLatePatientsByTherapistId(int id);
    }

    public class PatientRepository : IPatientRepository
    {
        private PhysicalTherapyContext _context;

        public PatientRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<Patient> Find(string username)
        {
            return await _context.Patients.Where(p => p.Username == username)
                .Include(p => p.Therapist)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients;
        }

        public IEnumerable<Patient> GetByTherapistId(int id)
        {
            return _context.Patients
                .Where(b => b.TherapistId.Equals(id));
        }

        public IEnumerable<Patient> GetLatePatientsByTherapistId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientsWithNewFeedbackByTherapistId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient> UpdateTherapist(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> FindById(int id)
        {
            return await _context.Patients.SingleOrDefaultAsync(pat => pat.PatientId == id);
        }
    }
}
