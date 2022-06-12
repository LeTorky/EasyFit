using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private ICoachManager _coachManager;
        public CoachController(ICoachManager coachManager)
        {
            _coachManager = coachManager;
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
        [HttpDelete]
        public IActionResult DeleteCoach()
        {
            if (_coachManager.DeleteCoach() == null)
                return NotFound();
            return Ok(_coachManager.GetAllCoaches());
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCoach(int id,Coach coach)
        {
            var result = _coachManager.UpdateCoach(id, coach);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}
