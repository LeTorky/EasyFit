using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoachingApp.Implementations;
using Microsoft.EntityFrameworkCore;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using CoachingApp.Models;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITest Test;
        private IdentityApplicationContext _context;
        private UserManager<IdentityApplicationUser> _userManager;
        private RoleManager<IdentityApplicationRoles> roleManager;
        public TestController(ITest test, IdentityApplicationContext context, UserManager<IdentityApplicationUser> userManager, RoleManager<IdentityApplicationRoles> _roleManager)
        {
            Test = test;
            _context = context;
            _userManager = userManager;
            roleManager = _roleManager;
        }
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            return await Test.TestMethod();
        }
        [HttpGet("SignIn")]
        //[Authorize(Roles ="Coach")]
        public async Task<bool> Testing()
        {
            await roleManager.CreateAsync(new IdentityApplicationRoles() { Name = "Client" });
            //var x= await _userManager.GetUserAsync(User);
            return true;
        }
    }
}
