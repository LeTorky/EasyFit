using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

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
            if (_coachManager.GetAllCoaches() == null)
                return NotFound();
            return Ok(_coachManager.GetAllCoaches());
        }
        [HttpDelete]
        public IActionResult DeleteCoach()
        {
            if (_coachManager.DeleteCoach() == null)
                return NotFound();
            return Ok(_coachManager.GetAllCoaches());
        }
        [HttpPut]
        public IActionResult UpdateCoach()
        {
            if (_coachManager.UpdateCoach() == null)
                return NotFound();
            return Ok(_coachManager.UpdateCoach());
        }

    }
}
