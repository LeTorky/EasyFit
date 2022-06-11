using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private IExerciseManager _exerciseManager;
        public ExerciseController(IExerciseManager exerciseManager)
        {
            _exerciseManager = exerciseManager;
        }
    }
}

