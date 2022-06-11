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
        [HttpPut("{id}")]
        public ActionResult UpdateExcercice(int id,Excercise excercice)
        {
            if (_exerciseManager.UpdateExcersise(id, excercice) == null)
                return NotFound();

            return Ok(_exerciseManager.UpdateExcersise(id, excercice));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExcercice(int id)
        {
            if (_exerciseManager.DeleteExcercice(id) == null)
                return NotFound();

            return Ok(_exerciseManager.DeleteExcercice(id));
        }
    }
}

