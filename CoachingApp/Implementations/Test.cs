using CoachingApp.Interfaces;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoachingApp.Implementations
{
    public class Test : ITest
    {
        private IdentityApplicationContext DBContext;
        private SignInManager<IdentityApplicationUser> _SignInManager;
        private RoleManager<IdentityApplicationRoles> RoleManager;
        public Test(IdentityApplicationContext _DBContext, SignInManager<IdentityApplicationUser> Manager, RoleManager<IdentityApplicationRoles> roleManager)
        {
            DBContext = _DBContext;
            _SignInManager = Manager;
            RoleManager = roleManager;
        }
        public async Task<ActionResult> TestMethod()
        {
            //var user = new IdentityApplicationUser() { UserName = "ElMans" };
            //await _SignInManager.UserManager.CreateAsync(user, "aA1@3000");
            //await RoleManager.CreateAsync(new IdentityApplicationRoles() { Name = "Coach" });
            //await _SignInManager.UserManager.AddToRoleAsync(user, "Coach");
            await _SignInManager.SignInAsync(DBContext.Users.FirstOrDefault(), isPersistent: true);
            var Result = new OkObjectResult(DBContext.Users.FirstOrDefault());
            return Result;
        }
    }
}
