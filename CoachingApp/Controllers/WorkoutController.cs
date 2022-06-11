using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private IWorkoutManager _workoutManager;
        public WorkoutController(IWorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }
    }
}

