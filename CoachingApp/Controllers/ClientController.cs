using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientManager _clientManager;
        private ICoachManager _coachManager;
        private readonly SignInManager<IdentityApplicationUser> _SignInManager;
        public ClientController(IClientManager clientManager, ICoachManager coachManager)
        {
            _clientManager = clientManager;
            _coachManager = coachManager;
        }


        

      
    }
}
