using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CoachingApp.Identity
{
    public class IdentityApplicationUser:IdentityUser<Guid>
    {
        public virtual Client? Client { get; set; }
        public virtual Coach? Coach { get; set; }

    }
}
