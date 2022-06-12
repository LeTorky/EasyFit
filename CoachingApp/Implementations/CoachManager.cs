using CoachingApp.Interfaces;

namespace CoachingApp.Implementations
{
    public class CoachManager:ICoachManager
    {
        private readonly IdentityApplicationContext _context;
        public CoachManager(IdentityApplicationContext context)
        {
            _context = context;
        }
        public bool isCoach(int id)
        {
            return _context.Coaches.Any(c=>c.id == id);
        }
    }
}
