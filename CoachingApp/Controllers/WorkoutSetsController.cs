using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class WorkoutSetsController : ControllerBase
    {
        private IWorkoutSetsManager _workoutSetsManager;
        private ICoachManager _coachManager;
        private readonly IdentityUserManager _signInManager;
        private Coach Coach;

        public WorkoutSetsController(IWorkoutSetsManager workoutSetsManager, IdentityUserManager signInManager, ICoachManager coachManager)
        {
            _workoutSetsManager = workoutSetsManager;
            _coachManager = coachManager;   
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles ="Coach")]
        public async Task<IActionResult> getWorkoutSetsByCoachID()
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (!_coachManager.isCoach(Coach.id))
                return NotFound("coach isnot registered!");
            return Ok(_workoutSetsManager.getWorkoutsByCoachID(Coach.id));
        }
        
        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> addWorkoutSet([FromBody] WorkoutSet workoutSet)
        {
            Coach = (await _signInManager.GetCoachAsync(User));

            if (!_coachManager.isCoach(Coach.id))
                return NotFound("coach isnot registered!");
            if (_workoutSetsManager.setExists(workoutSet.name, Coach.id))
                return BadRequest("this set already exits for this coach");
            if (workoutSet.coachID != Coach.id)
                return Unauthorized("you cannot add sets with other coach id");
            var newSet = await _workoutSetsManager.addWorkoutSet(workoutSet);
            return Ok(newSet);
        }
    
        [HttpPut("{setID}")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> updateWorkoutSet(int setID, [FromBody] WorkoutSet workoutSet)
        {
            Coach = (await _signInManager.GetCoachAsync(User));

            if (!_coachManager.isCoach(workoutSet.coachID))
                return NotFound("coach isnot registered!");
            if (!_workoutSetsManager.setExists(setID))
                return NotFound("workout set doesnot exist!");
            if (workoutSet.coachID != Coach.id)
                return Unauthorized("you cannot update sets of other coaches");
            WorkoutSet retval = await _workoutSetsManager.updateWorkoutSet(setID, workoutSet);
            return Ok(retval);
        }
        
        [HttpDelete("{setID}")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> deleteWorkoutSet(int setID)
        {
            Coach = (await _signInManager.GetCoachAsync(User));

            if (!_workoutSetsManager.setExists(setID))
                return NotFound("workout set doesnot exist!");
            var set = _workoutSetsManager.getWorkoutSet(setID).Result;
            if (set.coachID != Coach.id)
                return Unauthorized("you cannot delete sets of other coaches");
            WorkoutSet retval = await _workoutSetsManager.deleteWorkoutSet(setID);
            return Ok(retval);
        }
    }
}
