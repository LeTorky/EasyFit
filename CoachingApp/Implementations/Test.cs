using CoachingApp.Interfaces;
using CoachingApp.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoachingApp.Implementations
{
    public class Test : ITest
    {
        private IdentityApplicationContext DBContext;
        private SignInManager<IdentityApplicationUser> SignInManager;
        public Test(IdentityApplicationContext _DBContext, SignInManager<IdentityApplicationUser> Manager)
        {
            DBContext = _DBContext;
            SignInManager = Manager;
        }
        public async Task<ActionResult> TestMethod()
        {

            Console.WriteLine(DBContext.Users.FirstOrDefault().Client.age);
            return new OkResult();
        }
    }
}
