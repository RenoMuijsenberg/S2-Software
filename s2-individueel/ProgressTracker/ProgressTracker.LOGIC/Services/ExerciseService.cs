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
    public class ExerciseService : IExerciseService
    {
        private readonly ICrud _crud;
        private readonly IExercise _exercise;

        public ExerciseService(ICrud crud, IExercise exercise)
        {
            _crud = crud;
            _exercise = exercise;
        }


        public async Task<StandardResult> CreateExercise(ExerciseModel exercise)
        {
            var result = new StandardResult();
            try
            {
                var dalResult = await _crud.Create<ExerciseModel>(exercise);

                if (dalResult != null)
                {
                    result.success = true;
                    result.userMessage = string.Format("Successfully created exercise.");
                }
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = string.Format("Unsuccessfully created exercise.");
            }

            return result;
        }

        public async Task<GenericResult<List<ExerciseModel>>> GetAllExercises(Guid id)
        {
            var result = new GenericResult<List<ExerciseModel>>();
            try
            {
                var dalResult = await _exercise.GetAllExercises(id);

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
