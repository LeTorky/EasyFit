using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutSetsController : ControllerBase
    {
        private IWorkoutSetsManager _workoutSetsManager;
        public WorkoutSetsController(IWorkoutSetsManager workoutSetsManager)
        {
            _workoutSetsManager = workoutSetsManager;
        }
    }
}
