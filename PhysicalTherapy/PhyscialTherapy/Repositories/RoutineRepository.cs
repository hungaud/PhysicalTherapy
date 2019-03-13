using Microsoft.EntityFrameworkCore;
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
        Task<IEnumerable<Routine>> GetRecentRoutineCompletionsWithFeedback(int therapistId);
        Task<IEnumerable<Routine>> GetLateRoutinesByTherapistId(int therapistId);
        Task<IEnumerable<Routine>> GetFullRoutineByRoutineId(int RoutineId);
        Task<Routine> Add(Routine routine);
        Task<Routine> Put(Routine routine);
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
                .ThenInclude(re => re.Exercise)
                .Include(r => r.PostRoutineSurvey)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> GetRecentRoutineCompletionsWithFeedback(int therapistId)
        {
            DateTime cutoff = DateTime.Now;
            return await _context.Routines.Where(r => r.Patient.Therapist.TherapistId == therapistId
                && r.PostRoutineSurvey.Date.AddYears(1).CompareTo(cutoff) > 0)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.PostRoutineSurvey)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> GetLateRoutinesByTherapistId(int therapistId)
        {
            DateTime cutoff = DateTime.Now;
            return await _context.Routines.Where(r => r.Patient.Therapist.TherapistId == therapistId
                && !r.IsComplete
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
                .ThenInclude(re => re.Exercise)
                .Include(r => r.PostRoutineSurvey)
                .ToListAsync();
        }

        public async Task<IEnumerable<Routine>> GetFullRoutineByRoutineId(int routineId)
        {
            return await _context.Routines.Where(r => r.RoutineId == routineId)
                .Include(r => r.RoutineExercises)
                .ThenInclude(r => r.Exercise)
                .ToListAsync();
        }

        public IEnumerable<Routine> GetAll()
        {
            return _context.Routines
                .Include(r => r.ListOfMessageLogs)
                .Include(r => r.Patient.Therapist)
                .Include(r => r.RoutineExercises)
                .ThenInclude(re => re.Exercise)
                .Include(r => r.PostRoutineSurvey);
        }

        public async Task<Routine> Add(Routine routine)
        {
            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();
            return routine;
        }

        public async Task<Routine> Put(Routine routine)
        {
            Routine temp = _context.Routines.Where(r => routine.RoutineId == r.RoutineId).FirstOrDefault<Routine>();
            temp.IsComplete = true;
            temp.PostRoutineSurveyId = routine.PostRoutineSurveyId;
            await _context.SaveChangesAsync();
            return routine;
        }
    }
}
