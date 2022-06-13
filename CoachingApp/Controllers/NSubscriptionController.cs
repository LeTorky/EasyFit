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
        public async Task<IActionResult> NewNutSubs(Nutrition_Subscription nutrition_Subscription)
        {
            if (nutrition_Subscription==null)
            {
                return BadRequest("Client is not registerd");
            }
            var status= await _nSubscriptionManager.NewNutritionSubs(nutrition_Subscription);

            return Created("Nutration sub Created", nutrition_Subscription);
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> EditNutSubs(int id, Nutrition_Subscription nutrition_Subscription)
        {
            if (id != nutrition_Subscription.id)
            {
                return BadRequest();
            }

           

            return NoContent();
        }

        //delete sub
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteNutrition_Subscription(int id)
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
