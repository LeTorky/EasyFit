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
    }
}
