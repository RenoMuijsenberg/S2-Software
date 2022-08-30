using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;

namespace ProgressTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetController : Controller
    {
        private readonly ISetService _setService;

        public SetController(ISetService setService)
        {
            _setService = setService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExercise([FromBody] JObject sets)
        {
            var result = await _setService.CreateSet(sets);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetAllExercises(Guid id)
        {
            var result = await _setService.GetPrevSets(id);

            return Ok(result);
        }
    }
}