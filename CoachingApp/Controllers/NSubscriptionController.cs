using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSubscriptionController : ControllerBase
    {
        private INSubscriptionManager _nSubscriptionManager;
        public NSubscriptionController(INSubscriptionManager nSubscriptionManager)
        {
            _nSubscriptionManager = nSubscriptionManager;
        }
        // add new sub
        [HttpPost]
        public async Task<IActionResult> NewNutSubs(int ID, int Duration, int Price, int CoachId)
        {
            if (ID ==null && CoachId==null)
            {
                return BadRequest("Client is not registerd");
            }
            var newSub= await _nSubscriptionManager.NewNutritionSubs(ID,Duration,Price,CoachId);

            return Created("Nutration sub Created", newSub);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditNutSubs([FromRoute] int id, int Duration,  int Price, int CoachId )
        {
            var SubExists = await _nSubscriptionManager.GetNSubByCoachID(id, CoachId);

            if (SubExists)
            {
           var updated=  _nSubscriptionManager.EditNutritionSubs(id, Duration, Price, CoachId);
                return Ok(updated);
            }
            else
            {
                return NotFound("this Sub not foubd");
            }


        }

        //delete sub
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrition_Subscription([FromRoute]int id)
        {
            if (_nSubscriptionManager.GetNSubByID(id) == null)
                return NotFound("This Nutration Plan dose not exsits ");
            else
            {
                _nSubscriptionManager.DeleteNutritionSub(id);
                return Ok("Deleted Nutration");
            }

        }

    }
}
