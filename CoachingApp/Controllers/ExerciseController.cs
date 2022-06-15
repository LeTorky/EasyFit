using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private IExerciseManager _exerciseManager;
        public ExerciseController(IExerciseManager exerciseManager)
        {
            _exerciseManager = exerciseManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Excercise obj)
        {
            var ex = _exerciseManager.CreateExcercise(obj);
            if (ex != null)
            {
                return Ok(ex);
            }
            else { return BadRequest(); }
        }
    }
}

