using CoachingApp.Identity;
using CoachingApp.Implementations;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CoachingApp.Extensions
{
    public class UserManagerEXT : UserManager<IdentityApplicationUser>
    {
        private IdentityApplicationContext _context;
        public UserManagerEXT(IUserStore<IdentityApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<IdentityApplicationUser> passwordHasher, IEnumerable<IUserValidator<IdentityApplicationUser>> userValidators, IEnumerable<IPasswordValidator<IdentityApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<IdentityApplicationUser>> logger, IdentityApplicationContext context)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }
        public async Task<Coach> GetCoachAsync(ClaimsPrincipal User)
        {
            IdentityApplicationUser IdentityUser = await GetUserAsync(User);
            return _context.Coaches.Where(Coach => Coach.User == IdentityUser).FirstOrDefault();
        }
        public async Task<Client> GetClientAsync(ClaimsPrincipal User)
        {
            IdentityApplicationUser IdentityUser = await GetUserAsync(User);
            return _context.Clients.Where(Client => Client.User == IdentityUser).FirstOrDefault();
        }
    }
}
