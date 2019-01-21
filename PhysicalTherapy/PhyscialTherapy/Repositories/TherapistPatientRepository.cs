﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhysicalTherapy.Models;
using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Controllers;

namespace PhysicalTherapy.Repositories
{
    public interface ITherapistPatientRepository
    {
        Task<Patient> Find(string username);

        IEnumerable<Patient> GetAll();
    }

    public class TherapistPatientRepository : ITherapistPatientRepository
    {
        private PhysicalTherapyContext _context;

        public TherapistPatientRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<Patient> Find(string username)
        {
            return await _context.Patients.SingleOrDefaultAsync(cred => cred.Username == username);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients;
        }
    }
}
