using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NSubscriptionController : ControllerBase
    {
        private INSubscriptionManager _nSubscriptionManager;
        public NSubscriptionController(INSubscriptionManager nSubscriptionManager)
        {
            _nSubscriptionManager = nSubscriptionManager;
        }
    }
}
