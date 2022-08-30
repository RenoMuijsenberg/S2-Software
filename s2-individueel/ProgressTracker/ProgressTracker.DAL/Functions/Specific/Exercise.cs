using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;

namespace ProgressTracker.DAL.Functions.Specific
{
    public class Exercise : IExercise
    {
        private readonly DatabaseContext _db;

        public Exercise(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<List<ExerciseModel>> GetAllExercises(Guid id)
        {
            try
            {
                var result = await _db.Exercises.Where(x => x.SchemeId == id).ToListAsync();

                return result;
            }
            catch
            {
                throw;

            }
        }
    }
}
