using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoachingApp.Implementations;
using Microsoft.EntityFrameworkCore;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITest Test;
        private IdentityApplicationContext _context;
        private UserManager<IdentityApplicationUser> _userManager;
        public TestController(ITest test, IdentityApplicationContext context, UserManager<IdentityApplicationUser> userManager)
        {
            Test = test;
            _context = context;
            _userManager = userManager;
        }
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            return await Test.TestMethod();
        }
        [HttpGet("SignIn")]
        [Authorize(Roles ="Coach")]
        public async Task<IdentityApplicationUser> Testing()
        {
            return await _userManager.GetUserAsync(User);
        }
    }
}
