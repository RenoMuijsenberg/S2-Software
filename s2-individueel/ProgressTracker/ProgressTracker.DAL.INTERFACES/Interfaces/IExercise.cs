using ProgressTracker.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.DAL.INTERFACES.Interfaces
{
    public interface IExercise
    {
        Task<List<ExerciseModel>> GetAllExercises(Guid id);
    }
}
