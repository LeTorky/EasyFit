using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSubscriptionController : ControllerBase
    {
        private IWSubscriptionManager _wSubscriptionManager;
        public WSubscriptionController(IWSubscriptionManager wSubscriptionManager)
        {
            _wSubscriptionManager = wSubscriptionManager;
        }
    }
}
