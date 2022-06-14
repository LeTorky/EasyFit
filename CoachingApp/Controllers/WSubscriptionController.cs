using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSubscriptionController : ControllerBase
    {
        private IWSubscriptionManager _wSubscriptionManager;
        public WSubscriptionController(IWSubscriptionManager wSubscriptionManager)
        {
            _wSubscriptionManager = wSubscriptionManager;
        }
        // add new sub
        [HttpPost]
        public async Task<IActionResult> NewNutSubs(Workout_Subscription norkout_Subscription)
        {
            if (norkout_Subscription == null)
            {
                return BadRequest("Client is not registerd");
            }
            var status = await _wSubscriptionManager.NewWorkoutSubs(norkout_Subscription);

            return Created("Nutration sub Created", norkout_Subscription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditNutSubs([FromRoute] int id, Workout_Subscription norkout_Subscription)
        {
            if (id != norkout_Subscription.id)
            {
                return BadRequest();
            }

            _wSubscriptionManager.EditWorkoutSubs(norkout_Subscription);

            return Ok("Edited");
        }

        //delete sub
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout_Subscription([FromRoute] int id)
        {
            if (_wSubscriptionManager.GetWSubByID(id) == null)
                return NotFound("This Nutration Plan dose not exsits ");
            else
            {
                _wSubscriptionManager.DeleteWorkoutSub(id);
                return Ok("Deleted Nutration");
            }

        }
    }
}
