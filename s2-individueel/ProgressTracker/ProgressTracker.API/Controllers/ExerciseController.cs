using Microsoft.AspNetCore.Mvc;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;

namespace ProgressTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExercise([FromBody] ExerciseModel exercise)
        {
            var result = await _exerciseService.CreateExercise(exercise);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetAllExercises(Guid id)
        {
            var result = await _exerciseService.GetAllExercises(id);

            return Ok(result);
        }
    }
}
