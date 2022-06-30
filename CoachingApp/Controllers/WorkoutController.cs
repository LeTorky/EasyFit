using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CoachingApp.Identity;
using CoachingApp.DTO;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private IWorkoutManager _workoutManager;
        private ICoachManager _coachManager;
        private IWorkoutSetsManager _workoutSetsManager;
        private IWSubscriptionManager _wSubscriptionManager;
        private readonly IdentityUserManager _signInManager;
        private Coach Coach;
        private Client Client;

        public WorkoutController(IWorkoutManager workoutManager, ICoachManager coachManager, IdentityUserManager signInManager, IWorkoutSetsManager workoutSetsManager, IWSubscriptionManager wSubscriptionManager)
        {
            _workoutManager = workoutManager;
            _coachManager = coachManager;
            _signInManager = signInManager;
            _workoutSetsManager = workoutSetsManager;
            _wSubscriptionManager = wSubscriptionManager;
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> addWorkout([FromBody] Workout workout)
        {
            Coach Coach = (await _signInManager.GetCoachAsync(User));

            if (!_coachManager.isCoach(Coach.id))
                return NotFound("coach isnot registered!");
            if (workout.coachID != Coach.id)
                return Unauthorized("you cannot add a workout to another coach!");
            if (_workoutManager.workoutExists(workout.name, workout.coachID))
                return BadRequest("this workout already exits for this coach");
            var newWorkout = await _workoutManager.addWorkout(workout);
            return Ok(newWorkout);
        }

        [HttpPost("assignSet")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> assignWorkoutsViaWorkoutSet(int subID, int clientID, IEnumerable<WorkoutWithDateDto> workouts)
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (!_coachManager.isCoach(Coach.id))
                return NotFound("coach isnot registered!");
            var subscription = _wSubscriptionManager.getSubscription(subID);
            if (subscription == null)
                return NotFound("subscription doesnot exist!");
            if(subscription.coachID != Coach.id)
                return Unauthorized("you cannot add into a subscription thats not yours!");
            var clientworkoutSub = _workoutSetsManager.assignWorkoutsToClient(Coach.id, clientID, subID, workouts);

            return Ok(clientworkoutSub);
        }

        [HttpPut("{workoutID}")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> updateWorkout(int workoutID, [FromBody] Workout workout)
        {
            Coach = (await _signInManager.GetCoachAsync(User));

            if (!_coachManager.isCoach(Coach.id))
                return NotFound("coach isnot registered!");
            if (!_workoutManager.workoutExists(workout.id))
                return BadRequest("this workout doesnot exist!");
            if (workout.coachID != Coach.id)
                return Unauthorized("you cannot update a workout for another coach!");

            var mywo = _workoutManager.updateWorkout(workoutID, workout);
            return Ok(mywo);
        }

        [Authorize(Roles = "Client")]
        [HttpPut("{workoutID}/status")]
        public async Task<IActionResult> updateWorkoutStatus(int workoutID, int subID, DateTime woDate, int status, string clientNotes)
        {
            Client = (await _signInManager.GetClientAsync(User));
            if (!_workoutManager.workoutExists(workoutID))
                return BadRequest("this workout doesnot exist!");
            var mywo = _workoutManager.updateWorkoutStatus(workoutID, Client.id, subID, woDate, status, clientNotes);
            if (mywo == null)
                return NotFound("this client doesnot have this workout!");
            return Ok(mywo);
        }
        [HttpGet("Coach")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> getWorkoutsForCoach()
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            return Ok(_workoutManager.getWorkoutsByCoachId(Coach.id));
        }
        [HttpDelete("delete")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> deleteWorkOut(int workoutId)
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (_workoutManager.deleteWorkOut(Coach.id, workoutId))
                return Ok("Deleted Workout!");
            return BadRequest("Workout exists in a workout set, client workouts or doesn't exist!");
        }
    }
}

