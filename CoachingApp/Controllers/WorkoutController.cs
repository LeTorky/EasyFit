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
            if (_workoutManager.workoutExists(workout.name, Coach.id))
                return BadRequest("this workout already exits for this coach");
            workout.coachID = Coach.id;
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
        [HttpDelete("{workoutId}")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> deleteWorkOut(int workoutId)
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (_workoutManager.deleteWorkOut(Coach.id, workoutId))
                return Ok("Deleted Workout!");
            return BadRequest("Workout exists in a workout set, client workouts or doesn't exist!");
        }
        [HttpGet("workoutClientSub")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> getClientSubWorkOuts(int SubId)
        {
            Client = (await _signInManager.GetClientAsync(User));
            if(Client == null)
                return Unauthorized("Please Sign In");
            return Ok(_workoutManager.getWorkoutByClientSub(Client.id, SubId));
        }
        [HttpGet("workoutClientSubCoach")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> getClientSubWorkOutsCoach(int ClientId, int SubId)
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (Coach == null)
                return Unauthorized("Please Sign In");
            return Ok(_workoutManager.getWorkoutByClientSubCoach(Coach.id, ClientId, SubId));
        }
        [HttpPost("addWorkOutClientSub")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> addWorkOutClientSub(int WorkoutId, int ClientId, int subId, string Notes)
        {
            Coach = (await _signInManager.GetCoachAsync(User));
            if (Coach == null)
                return Unauthorized("Please Sign In");
            if (_workoutManager.addWorkOutToClientSub(WorkoutId, ClientId, subId, Coach.id, Notes))
                return Ok("Added Successfully!");
            return BadRequest("Make sure the workout exists and client is suscribed!");
        }
    }
}

