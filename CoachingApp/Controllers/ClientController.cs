using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientManager _clientManager;
        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
    }
}
