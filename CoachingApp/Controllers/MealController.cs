using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMealManager _mealManager;
        public MealController(IMealManager mealManager)
        {
            _mealManager = mealManager;
        }
    }
}
