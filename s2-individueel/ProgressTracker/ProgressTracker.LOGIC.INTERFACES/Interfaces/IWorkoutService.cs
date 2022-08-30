using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.LOGIC.INTERFACES.Interfaces
{
    public interface IWorkoutService
    {
        Task<StandardResult> CreateWorkout(WorkoutModel workout);
        Task<GenericResult<List<WorkoutModel>>> GetAllWorkouts(Guid id);
    }
}
