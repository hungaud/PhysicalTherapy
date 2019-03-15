using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Repositories
{

    public interface IRoutineExerciseRepository
    {
        IEnumerable<RoutineExercise> GetAll();
        Task<RoutineExercise> Add(RoutineExercise routineExercise);
    }

    public class RoutineExerciseRepository : IRoutineExerciseRepository
    {
        private PhysicalTherapyContext _context;

        public RoutineExerciseRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public IEnumerable<RoutineExercise> GetAll()
        {
            return _context.RoutineExercises;
        }

        public async Task<RoutineExercise> Add(RoutineExercise routineExercise)
        {
            _context.RoutineExercises.Add(routineExercise);
            await _context.SaveChangesAsync();
            return routineExercise;
        }
    }
}