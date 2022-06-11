using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoachingApp.Implementations;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITest Test;
        private IdentityApplicationContext _context;
        public TestController(ITest test, IdentityApplicationContext context)
        {
            Test = test;
            _context = context;
        }
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            return await Test.TestMethod();
        }
        [HttpGet("SignIn")]
        public object Testing()
        {
            return _context.Users.FirstOrDefault();
        }
    }
}
