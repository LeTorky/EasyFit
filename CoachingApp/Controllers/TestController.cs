using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITest Test;
        public TestController(ITest test)
        {
            Test = test;
        }
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            return await Test.TestMethod();
        }
        [HttpGet("SignIn")]
        [Authorize(Roles = "COACH")]
        public ActionResult Testing()
        {
            return new OkResult();
        }
    }
}
