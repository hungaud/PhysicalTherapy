﻿using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Repositories
{

    public interface IRoutineRepository
    {
        IEnumerable<Routine> GetAll();
        Task<IEnumerable<Routine>> Get(int patientId);
        Task<IEnumerable<Routine>> Get(string patientUsername);
    }

    public class RoutineRepository : IRoutineRepository
    {
        private PhysicalTherapyContext _context;

        public RoutineRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Routine>> Get(int patientId)
        {
            return await _context.Routines.Where(r => r.PatientId == patientId)
                .Include(r => r.ListOfMessageLogs)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.RoutineExercises)
                .Include(r => r.PostRoutineSurvey)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> Get(string patientUsername)
        {
            return await _context.Routines.Where(r => r.Patient.Username == patientUsername)
                .Include(r => r.ListOfMessageLogs)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.RoutineExercises)
                .Include(r => r.PostRoutineSurvey)
                .ToListAsync();
        }

        public IEnumerable<Routine> GetAll()
        {
            return _context.Routines;
        }
    }
}