using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ProgressTracker.API.Controllers
{
/*    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]*/
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutModel workout)
        {
            var result = await _workoutService.CreateWorkout(workout);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetAllWorkouts(Guid id)
        {
            var result = await _workoutService.GetAllWorkouts(id);

            return Ok(result);
        }
    }
}
