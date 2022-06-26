using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSubscriptionController : ControllerBase
    {
        private IWSubscriptionManager _wSubscriptionManager;
        private readonly SignInManager<IdentityApplicationUser> _SignInManager;
        private IClientManager _clientManager;

        private ICoachManager _coachManager;
        public WSubscriptionController(IWSubscriptionManager wSubscriptionManager, IClientManager clientManager, ICoachManager coachManager, SignInManager<IdentityApplicationUser> signInManager)
        {
            _wSubscriptionManager = wSubscriptionManager;
            _clientManager = clientManager;
            _coachManager = coachManager;
            _SignInManager = signInManager;
        }
        // add new sub
        [HttpPost]
        public async Task<IActionResult> NewNutSubs(int ID, int Duration, int Price, int CoachId)
        {
            if (ID == null && CoachId == null)
            {
                return BadRequest("Client is not registerd");
            }
            var newSub = await _wSubscriptionManager.NewWorkoutSubs(ID, Duration, Price, CoachId);

            return Created("Nutration sub Created", newSub);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditNutSubs([FromRoute] int id, int Duration, int Price, int CoachId)
        {
            var SubExists = await _wSubscriptionManager.GetWSubByCoachID(id, CoachId);

            if (SubExists)
            {
                var updated = await _wSubscriptionManager.EditWorkoutSubs(id, Duration, Price, CoachId);
                return Ok(updated);
            }
            else
            {
                return NotFound("this Sub not foubd");
            }


        }

        //delete sub
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrition_Subscription([FromRoute] int id)
        {
            if (_wSubscriptionManager.GetWSubByID(id) == null)
                return NotFound("This Nutration Plan dose not exsits ");
            else
            {
                _wSubscriptionManager.DeleteWorkoutSub(id);
                return Ok("Deleted Nutration");
            }

        }

        //Add new entry tothe client-nutration sub table
        [HttpPost("NewSubRequest")]
        public async Task<IActionResult> NewNutrSubRequest(int ClientId, int SubId, DateTime date, int CoachId)
        {
            //var Client = (await _SignInManager.UserManager.GetUserAsync(User)).Client;
            //if (_clientManager.GetClientByID(Client.id) == null)
            //    return BadRequest("Client is not registerd");
            if (ClientId == 0)
                return BadRequest("Client is not registerd");

            var NewEntry = await _wSubscriptionManager.NewWorkoutSubRequest(ClientId, SubId, date, CoachId);
            return Ok(NewEntry);

        }

        [HttpPut("CoachChangeSubStatus")]
        public async Task<IActionResult> SubStatseChange(int ClientId, int SubId, DateTime StartDate, int CoachId, bool status, DateTime RequestDate)
        {

            //var Coach = (await _SignInManager.UserManager.GetUserAsync(User)).Coach;
            //if (_coachManager.GetClientByID(Client.id) == null)
            //    return BadRequest("Client is not registerd");
            if (CoachId == 0)
                return BadRequest("Coach is not registerd");
            var NewEntry = await _wSubscriptionManager.WSubStatusChange(ClientId, SubId, StartDate, CoachId, status, RequestDate);
            if (NewEntry == null)
                return BadRequest("Subscariton is not Availale");

            return Ok(NewEntry);

        }








        //get all sub for client
        [HttpGet("WorkoutSubsClient")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetWorkoutSubs()
        {

            var Client = (await _SignInManager.UserManager.GetUserAsync(User)).Client;

            if (_clientManager.GetClientByID(Client.id) == null)
                return BadRequest("Client is not registerd");

            var subs = await _clientManager.GetallClientWsub(Client.id);

            if (subs == null)
                return Ok("Client has no workout subscription");

            return Ok(subs);

        }




        //get all sub for coach
        [HttpGet("WorkoutSubsCoach")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> GetWorkoutSubsCoach()
        {

            var Coach = (await _SignInManager.UserManager.GetUserAsync(User)).Coach;

            if (_coachManager.GetCoachByID(Coach.id) == null)
                return BadRequest("Client is not registerd");

            var subs = await _coachManager.GetCoachByID(Coach.id);

            if (subs == null)
                return Ok("Client has no workout subscription");

            return Ok(subs);

        }
    }
}
