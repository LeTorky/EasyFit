using CoachingApp.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.DTO;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityApplicationUser> _signInManager;
        private ICoachManager _coachManager;
        private IClientManager _clientManager;
        public AccountController(SignInManager<IdentityApplicationUser> signInManager, ICoachManager coachManager, IClientManager clientManager)
        {
            _signInManager = signInManager;
            _coachManager = coachManager;
            _clientManager = clientManager;
        }

        [HttpPost("CoachRegister")]
        public async Task<IActionResult> CoachRegister(CoachUserDTO CoachDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect user credentials!");
            IdentityApplicationUser NewUser = new IdentityApplicationUser() { UserName = CoachDTO.UserName };
            NewUser.Email = CoachDTO.Email;
            if ((await _signInManager.UserManager.CreateAsync(NewUser, CoachDTO.PassWord)).Succeeded)
            {
                await _signInManager.UserManager.AddToRoleAsync(NewUser, "Coach");
                _coachManager.CreateCoach(CoachDTO, NewUser.Id);
                _signInManager.SignInAsync(NewUser, isPersistent: false);
                return Ok(NewUser);
            }
            return BadRequest("UserName or Email already exists!");
        }

        [HttpPost("ClientRegister")]
        public async Task<IActionResult> ClientRegister(ClientUserDTO ClientDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect user credentials!");
            IdentityApplicationUser NewUser = new IdentityApplicationUser() { UserName = ClientDTO.UserName };
            NewUser.Email = ClientDTO.Email;
            if ((await _signInManager.UserManager.CreateAsync(NewUser, ClientDTO.PassWord)).Succeeded)
            {
                await _signInManager.UserManager.AddToRoleAsync(NewUser, "Client");
                _clientManager.CreateClient(ClientDTO, NewUser.Id);
                _signInManager.SignInAsync(NewUser, isPersistent: false);
                return Ok(NewUser);
            }
            return BadRequest("UserName or Email already exists!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO UserLogin)
        {
            if ((await _signInManager.PasswordSignInAsync(UserLogin.UserName, UserLogin.Password, isPersistent:false, lockoutOnFailure: false)).Succeeded)
            {
                //await _signInManager.SignInAsync(new IdentityApplicationUser() { UserName = UserLogin.UserName }, isPersistent: true);
                return Ok(UserLogin);
            }
            return BadRequest(UserLogin);
        }

        [HttpGet("LogOut")]
        [Authorize(Roles = "Coach,Client")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Logged out successfully!");
        }
    }
}
