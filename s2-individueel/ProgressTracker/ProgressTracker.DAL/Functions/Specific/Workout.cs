using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.DAL.Functions.Specific
{
    public class Workout : IWorkout
    {
        private readonly DatabaseContext _db;

        public Workout(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<List<WorkoutModel>> GetAllWorkouts(Guid id)
        {
            try
            {
                var result = await _db.Workouts.Where(x => x.UserId == id).ToListAsync();

                return result;
            }
            catch
            {
                throw;

            }
        }
    }
}
