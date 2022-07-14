using CoachingApp.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.DTO;
using CoachingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<IdentityApplicationUser> _signInManager;
        private IdentityUserManager _userManager;
        private ICoachManager _coachManager;
        private IClientManager _clientManager;
        public AccountController(SignInManager<IdentityApplicationUser> signInManager, ICoachManager coachManager, IClientManager clientManager, IdentityUserManager userManager)
        {
            _signInManager = signInManager;
            _coachManager = coachManager;
            _clientManager = clientManager;
            _userManager = userManager;
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
                return Ok(new {Role="Coach"});
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
                return Ok(new { Role = "Client" });
            }
            return BadRequest("UserName or Email already exists!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO UserLogin)
        {
            if ((await _signInManager.PasswordSignInAsync(UserLogin.UserName, UserLogin.Password, isPersistent:false, lockoutOnFailure: false)).Succeeded)
            {
                string Role;
                if(await _userManager.GetClientAsync(User) != null)
                {
                    Role = "Client";
                }
                else if(await _userManager.GetCoachAsync(User) != null)
                {
                    Role = "Coach";
                }
                else
                {
                    Role = "None";
                }
                return Ok(new {Role = Role });
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

        [HttpPost("ChangePassword")]
        [Authorize(Roles = "Coach,Client")]
        public async Task<IActionResult> ChangePassword(UserChangePassDTO PasswordDTO)
        {
            IdentityApplicationUser EditUser = await _signInManager.UserManager.GetUserAsync(User);
            if (!(await _signInManager.UserManager.CheckPasswordAsync(EditUser, PasswordDTO.Password)))
                return BadRequest("Incorrect Password");
            if (!(await _signInManager.UserManager.ChangePasswordAsync(EditUser, PasswordDTO.Password, PasswordDTO.NewPassword)).Succeeded)
                return BadRequest("New Password is Invalid!");
            return Ok("Password successfully changed!");
        }

        [HttpPost("ChangeEmail")]
        [Authorize(Roles = "Coach,Client")]
        public async Task<IActionResult> ChangeEmail(UserChangeEmailDTO EmailDTO)
        {
            IdentityApplicationUser EditUser = await _signInManager.UserManager.GetUserAsync(User);
            if (!(await _signInManager.UserManager.CheckPasswordAsync(EditUser, EmailDTO.Password)))
                return BadRequest("Incorrect Password");
            if (EditUser.Email == EmailDTO.Email)
                return BadRequest("Duplicate Email!");
            if ((await _signInManager.UserManager.FindByEmailAsync(EmailDTO.Email)) != null)
                return BadRequest("There is already an account associated with this Email!");
            string EmailToken = await _signInManager.UserManager.GenerateChangeEmailTokenAsync(EditUser, EmailDTO.Email);
            var fromAddress = new MailAddress("apextorky@gmail.com", "EasyFit - NoReply");
            var toAddress = new MailAddress(EmailDTO.Email, $"Dear {EditUser.UserName},");
            const string fromPassword = "wxyodxlcrkwvglpk";
            const string subject = "Token";
            string body = $"<!DOCTYPE html><html><head>  <meta charset='utf-8'>  <meta http-equiv='x-ua-compatible' content='ie=edge'>  <title>Email Confirmation</title>  <meta name='viewport' content='width=device-width, initial-scale=1'>  <style type='text/css'>    img {{    -ms-interpolation-mode: bicubic;  }}   a[x-apple-data-detectors] {{    font-family: inherit !important;    font-size: inherit !important;    font-weight: inherit !important;    line-height: inherit !important;    color: inherit !important;    text-decoration: none !important;  }}    div[style*='margin: 16px 0;'] {{    margin: 0 !important;  }}  body {{    width: 100% !important;    height: 100% !important;    padding: 0 !important;    margin: 0 !important;  }}   table {{    border-collapse: collapse !important;  }}  a {{    color: #00a7f5;  }}  img {{    height: auto;    line-height: 100%;    text-decoration: none;    border: 0;    outline: none;  }}  </style></head><body style='background-color: #e9ecef;'>    <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>    A preheader is the short summary text that follows the subject line when an email is viewed in the inbox.  </div>   <table border='0' cellpadding='0' cellspacing='0' width='100%'>    <tr>      <td align='center' bgcolor='#e9ecef'>              <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>          <tr>            <td align='center' valign='top' style='padding: 36px 24px;'>              <a href='#' target='_blank' style='display: inline-block;'>                <img src='' alt='Logo' border='0' width='48' style='display: block; width: 48px; max-width: 48px; min-width: 48px;'>              </a>            </td>          </tr>        </table>              </td>    </tr>       <tr>      <td align='center' bgcolor='#e9ecef'>                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>          <tr>            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; border-top: 3px solid #d4dadf;'>              <h1 style='margin: 0; font-size: 24px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Confirm Your Request to Change Email Address </h1>            </td>          </tr>        </table>           </td>    </tr>        <tr>      <td align='center' bgcolor='#e9ecef'>                <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>                    <tr>            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;'>              <p style='margin: 0;'>Tap the button below to confirm your email address changed. If you didn't change your account email with <a href='#'>Easy Fit</a>, you can safely delete this email.</p>            </td>          </tr>                   <tr>            <td align='left' bgcolor='#ffffff'>              <table border='0' cellpadding='0' cellspacing='0' width='100%'>                <tr>                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>                    <table border='0' cellpadding='0' cellspacing='0'>                      <tr>                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>                          <a href='https://localhost:7109/api/Account/ConfirmEmail?Token={{EmailToken}}&Email={{EmailDTO.Email}}&OldEmail={{EditUser.Email}}'  target='_blank' style='display: inline-block; padding: 16px 36px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Confirm </a>                        </td>                      </tr>                    </table>                  </td>                </tr>              </table>            </td>          </tr>                  <tr>            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>              <p style='margin: 0;'>Cheers,<br> Paste</p>            </td>          </tr>                 </table>           </td>    </tr>    <tr>      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>              <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>                    <tr>            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;'>              <p style='margin: 0;'>You received this email because we received a request for change of the Email for your account. If you didn't request change Email address you can safely delete this email.</p>            </td>          </tr>        </table>            </td>    </tr>     </table></body></html>";
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
            return Ok("Token generated!");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ChangeEmailToken([FromQuery]UserConfirmToken Confirm)
        {
            Confirm.Token = Confirm.Token.Replace(" ", "+");
            IdentityApplicationUser EditUser = await _signInManager.UserManager.FindByEmailAsync(Confirm.OldEmail);
            if (!(await _signInManager.UserManager.ChangeEmailAsync(EditUser, Confirm.Email, Confirm.Token)).Succeeded)
                return BadRequest("Token is Invalid!");
            return Ok("Email updated successfully!");
        }
    }
}
