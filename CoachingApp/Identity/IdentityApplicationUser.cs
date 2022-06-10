using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CoachingApp.Identity
{
    public class IdentityApplicationUser:IdentityUser
    {
        public virtual client? Client { get; set; }
        public virtual coach? Coaches { get; set; }

    }
}
