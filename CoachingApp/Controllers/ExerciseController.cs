using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private IExerciseManager _exerciseManager;
        private SignInManager<IdentityApplicationUser> _signInManager;

        public ExerciseController(IExerciseManager exerciseManager, SignInManager<IdentityApplicationUser> _SignInManager)
        {
            _exerciseManager = exerciseManager;
            _signInManager = _SignInManager;
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

        [HttpGet("coachExcercices")]
        [Authorize]
        public async Task<IActionResult> CoachProfile()
        {
           
            var x = User;
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var result = _exerciseManager.GetAllExcercisesForCoach(user);

            if (result == null)
                return NotFound();
            return Ok(result);
        }


    }
}

