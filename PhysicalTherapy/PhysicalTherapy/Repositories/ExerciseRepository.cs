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
    public interface IExerciseRepository
    {
        Task<Exercise> Add(Exercise exercise);

        Task<Exercise> Find(string username);

        IEnumerable<Exercise> GetAll();
    }

    public class ExerciseRepository : IExerciseRepository
    {
        private PhysicalTherapyContext _context;

        public ExerciseRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<Exercise> Find(string name)
        {
            return await _context.Exercises.SingleOrDefaultAsync(exercise => exercise.Name == name);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _context.Exercises.OrderBy(e => e.Name);
        }

        public async Task<Exercise> Add(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }
    }
}
