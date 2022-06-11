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
            var result = _exerciseManager.UpdateExcersise(id, excercice);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExcercice(int id)
        {
            var result = _exerciseManager.DeleteExcercice(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet]
        public ActionResult GetAll(int id)
        {
            

            return Ok(_exerciseManager.GetAllExcercises());
        }

    }
}

