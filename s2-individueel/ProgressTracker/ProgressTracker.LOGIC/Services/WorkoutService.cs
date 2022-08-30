using DALInterfaces.Interfaces;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.LOGIC.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ICrud _crud;
        private readonly IWorkout _workout;

        public WorkoutService(ICrud crud, IWorkout workout)
        {
            _crud = crud;
            _workout = workout;
        }

        public async Task<StandardResult> CreateWorkout(WorkoutModel workout)
        {
            var result = new StandardResult();
            try
            {
                var dalResult = await _crud.Create<WorkoutModel>(workout);

                if (dalResult != null)
                {
                    result.success = true;
                    result.userMessage = string.Format("Successfully created workout.");
                }
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("Unsuccessfully created workout.");
            }

            return result;
        }

        public async Task<GenericResult<List<WorkoutModel>>> GetAllWorkouts(Guid id)
        {
            var result = new GenericResult<List<WorkoutModel>>();
            try
            {
                var dalResult = await _workout.GetAllWorkouts(id);

                if (dalResult != null)
                {
                    result.result = dalResult;
                    result.success = true;
                }
            }
            catch (Exception exception)
            {
                result.exception = exception;
            }

            return result;
        }
    }
}
