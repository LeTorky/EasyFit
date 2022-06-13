using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientManager _clientManager;
        private readonly SignInManager<IdentityApplicationUser> _SignInManager;
        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }


        [HttpGet("/NutraionSubs")]
        [Authorize("Client")]
        public async Task<IActionResult> GetNutritionSubs()
        {
            var Client = (await _SignInManager.UserManager.GetUserAsync(User)).Client;

            if (_clientManager.GetClientByID(Client.id) == null)
                return BadRequest("Client is not registerd");


            var subs = await _clientManager.GetallClientNsub(Client.id);

            if (subs == null)
                return Ok("Client has no Nutrition subscription");

            return Ok(subs);

        }

        [HttpGet("/WorkoutSubs")]
        [Authorize("Client")]
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
    }
}
