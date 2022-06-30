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
        private readonly IdentityUserManager _SignInManager;
        private IClientManager _clientManager;
      
        private ICoachManager _coachManager;

        public NSubscriptionController(INSubscriptionManager nSubscriptionManager, IClientManager clientManager,ICoachManager coachManager, IdentityUserManager signInManager)
        {
            _nSubscriptionManager = nSubscriptionManager;
            _clientManager = clientManager;
            _coachManager = coachManager;
            _SignInManager = signInManager;
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
           var updated= await  _nSubscriptionManager.EditNutritionSubs(id, Duration, Price, CoachId);
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

        //Add new entry tothe client-nutration sub table
        [HttpPost("NewSubRequest")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> NewNutrSubRequest( int SubId,DateTime date,int CoachId)
        {
            var Client = (await _SignInManager.GetClientAsync(User));

            if (Client == null)
                return BadRequest("Client is not registerd");
            

            var NewEntry= _nSubscriptionManager.NewNutrRequest(Client.id, SubId, date, CoachId);
            return Ok(NewEntry);

        }

        [HttpPut("CoachChangeSubStatus")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> SubStatseChange( int ClientId,int SubId,DateTime StartDate,bool status,DateTime RequestDate)
        {

            var Coach = (await _SignInManager.GetCoachAsync(User));

            if (Coach == null)
                return BadRequest("Coach is not registerd");
            var NewEntry = await _nSubscriptionManager.NSubStatusChange(ClientId, SubId, StartDate, Coach.id, status, RequestDate);
            if (NewEntry == null)
                return BadRequest("Subscariton is not Availale");

            return Ok(NewEntry);    

        }
        //get all sub nut for coach
        [HttpGet("NutraionSubsCoach")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> GetNutritionSubsCoach()
        {

            var Coach = (await _SignInManager.GetCoachAsync(User));

            if (Coach==null)
                return BadRequest("Coach is not registerd");


            var subs = await _nSubscriptionManager.GetallCoachNsub(Coach.id);

            if (subs == null)
                return Ok("Client has no Nutrition subscription");

            return Ok(subs);

        }
        //get all sub nut for coach
        [HttpGet("NutraionSubsClient")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetNutritionSubs()
        {

            var Client = (await _SignInManager.GetClientAsync(User));

            if (Client== null)
                return BadRequest("Client is not registerd");


            var subs = await _nSubscriptionManager.GetallClientNsub(Client.id);

            if (subs == null)
                return Ok("Client has no Nutrition subscription");

            return Ok(subs);

        }


    }
}
