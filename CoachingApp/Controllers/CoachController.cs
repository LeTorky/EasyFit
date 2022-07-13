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
    public class CoachController : ControllerBase
    {
        private ICoachManager _coachManager;
        private IdentityUserManager _signInManager;
        public CoachController(ICoachManager coachManager, IdentityUserManager _SignInManager)
        {
            _coachManager = coachManager;
            _signInManager = _SignInManager;
        }
        [HttpGet("{id}")]
        public IActionResult GetCoachById(int id)
        {
            if(_coachManager.GetCoachById(id)==null)
                return NotFound();
            return Ok(_coachManager.GetCoachById(id));
        }
        [HttpGet]
        public IActionResult GetAllCoaches()
        {
            var result=_coachManager.GetAllCoaches();
            if (result== null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCoach(int id)
        {
            var result = _coachManager.DeleteCoach(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCoach(int id,Coach coach)
        {
            var result = _coachManager.UpdateCoach(id, coach);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("profile")]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> CoachProfile()
        {
            //get the signed in coach
            //signinmanger->for signining in
            //UserManager->to make operation on the signin manger
            //GetUserAsync->using the get from usermanger get the coach using claims
            //User is teh claim contaning small data about the signed in person
            var x = User;
            var user = await  _signInManager.GetCoachAsync(User);
 

            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
