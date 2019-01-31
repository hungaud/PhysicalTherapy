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
        Task<IEnumerable<Routine>> GetRecentFeedback(int therapistId);
        Task<IEnumerable<Routine>> GetLatePatients(int therapistId);
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

        public async Task<IEnumerable<Routine>> GetRecentFeedback(int therapistId)
        {
            DateTime cutoff = DateTime.Now;
            return await _context.Routines.Where(r => r.Patient.Therapist.TherapistId == therapistId
                && r.PostRoutineSurvey.Date.AddYears(1).CompareTo(cutoff) > 0)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.PostRoutineSurvey)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> GetLatePatients(int therapistId)
        {
            DateTime cutoff = DateTime.Now;
            return await _context.Routines.Where(r => r.Patient.Therapist.TherapistId == therapistId
                && r.IsComplete == false
                && r.Date.AddYears(1).CompareTo(cutoff) < 0)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.PostRoutineSurvey)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> Get(string patientUsername)
        {
            return await _context.Routines.Where(r => r.Patient.Username == patientUsername)
                .Include(r => r.ListOfMessageLogs)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.RoutineExercises)
                .Include(r => r.PostRoutineSurvey)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public IEnumerable<Routine> GetAll()
        {
            return _context.Routines
                .Include(r => r.ListOfMessageLogs)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.RoutineExercises)
                .Include(r => r.PostRoutineSurvey);
        }
    }
}
